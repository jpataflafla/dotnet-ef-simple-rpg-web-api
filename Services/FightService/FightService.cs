using dotnet_ef_simple_rpg_web_api.Data;
using dotnet_ef_simple_rpg_web_api.Dtos.Character;
using dotnet_ef_simple_rpg_web_api.Dtos.Fight;
using dotnet_ef_simple_rpg_web_api.Models;
using dotnet_ef_simple_rpg_web_api.Services.CharacterService;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ef_simple_rpg_web_api.Services.FightService;

public class FightService : IFightService
{
    private static readonly int DefaultHitPoints = 100;
    private static readonly float MinStrengthFactor = 0.5f;
    private static readonly float MinDefenseFactor = 0.5f;
    private static readonly float StrengthRelevanceFactor = 0.6f; // more than 1 makes no sense
    private static readonly float MinIntelligenceFactor = 0.8f;
    private static readonly float SkillComplexityRelevanceFactor = 0.8f;
    private DataContext _dataContext;
    private readonly ICharacterService _characterService;
    private readonly Random _random;

    public FightService(DataContext dataContext, ICharacterService characterService)
    {
        _dataContext = dataContext;
        _characterService = characterService;
        _random = new Random();
    }

    public async Task<ServiceResponse<WeaponAttackResultResponseDto>> WeaponAttack(WeaponAttackRequestDto weaponAttackRequestDto)
    {
        var response = new ServiceResponse<WeaponAttackResultResponseDto>();
        try
        {
            var attacker = await GetAttackerAsync(weaponAttackRequestDto.AttackerId);
            var attackerWeapon = GetAttackerWeapon(attacker, weaponAttackRequestDto.AttackerWeaponId);
            var opponent = await GetOpponentAsync(weaponAttackRequestDto.OpponentId);

            int damage = CalculateWeaponAttackDamage(attacker, attackerWeapon, opponent);

            response.Message = ApplyDamage(attacker, opponent, damage);

            await _dataContext.SaveChangesAsync();

            response.Data = new WeaponAttackResultResponseDto()
            {
                AttackerName = attacker.Name,
                OpponentName = opponent.Name,
                AttackerHP = attacker.HitPoints,
                OpponentHP = opponent.HitPoints,
                Damage = damage
            };
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<ServiceResponse<SkillAttackResultResponseDto>> SkillAttack
        (SkillAttackRequestDto skillAttackRequestDto)
    {
        var response = new ServiceResponse<SkillAttackResultResponseDto>();
        try
        {
            var attacker = await GetAttackerAsync(skillAttackRequestDto.AttackerId);
            var attackerSkill = GetAttackerSkill(
                attacker, skillAttackRequestDto.AttackerSkillId);
            var opponent = await GetOpponentAsync(skillAttackRequestDto.OpponentId);

            int damage = CalculateSkillAttackDamage(attacker, attackerSkill, opponent);

            response.Message = ApplyDamage(attacker, opponent, damage);

            await _dataContext.SaveChangesAsync();

            response.Data = new SkillAttackResultResponseDto()
            {
                AttackerName = attacker.Name,
                OpponentName = opponent.Name,
                AttackerHP = attacker.HitPoints,
                OpponentHP = opponent.HitPoints,
                Damage = damage
            };
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<ServiceResponse<FightResultResponseDto>> AutomaticFight
        (FightRequestDto fightRequestDto)
    {
        var response = new ServiceResponse<FightResultResponseDto>()
        {
            Data = new FightResultResponseDto()
        };
        try
        {
            var charactersInvolved = await _dataContext.Characters
                .Include(character => character.Weapons)
                .Include(character => character.Skills)
                .Where(character => fightRequestDto.CharacterIds.Contains(character.Id))
                .ToListAsync();

            if (charactersInvolved is null || charactersInvolved.Count == 0)
            {
                throw new Exception("No characters with given Ids found.");
            }

            ConductAFightBetweenCharacters(response.Data.FightLog, charactersInvolved);

            ResetHitPointsAndCountFight(charactersInvolved);

            await _dataContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;
        }
        return response;
    }

    private async Task<Character> GetAttackerAsync(int attackerId)
    {
        // Character Service implementation should return attacker instance
        // at least with a list of Weapons and Skills (or just full character data). Example:
        // var attacker = await _dataContext.Characters
        //     .Include(character => character.Weapons)
        //     .Include(character => character.Skills)
        //     .SingleOrDefaultAsync(character => character.Id == attackerId) ??
        //     throw new Exception(
        //          $"Attacker with Id: {attackerId} not found.");

        var attacker = await _characterService.GetRawCharacterById(attackerId);
        if (attacker is null || attacker.Id != attackerId)
        {
            throw new Exception(
                $"Attacker with Id: {attackerId} not found.");
        }

        return attacker;
    }

    private Weapon GetAttackerWeapon(Character attacker, int attackerWeaponId)
    {
        if (attacker.Weapons is null || attacker.Weapons.Count == 0)
        {
            throw new Exception($"Attacker (Name: {attacker.Name} Id: {attacker.Id}) has no weapons.");
        }

        var attackerWeapon = attacker.Weapons.Find(weapon => weapon.Id == attackerWeaponId) ??
             throw new Exception($"Weapon with Id: {attackerWeaponId} not found.");

        return attackerWeapon;
    }

    private Skill GetAttackerSkill(Character attacker, int attackerSkillId)
    {
        if (attacker.Skills is null || attacker.Skills.Count == 0)
        {
            throw new Exception(
                $"Attacker (Name: {attacker.Name} Id: {attacker.Id}) has no skills.");
        }

        var attackerSkill = attacker.Skills.Find(weapon => weapon.Id == attackerSkillId) ??
             throw new Exception($"Skill with Id: {attackerSkillId} not found.");

        return attackerSkill;
    }

    private async Task<Character> GetOpponentAsync(int opponentId)
    {
        var opponent = await _dataContext.Characters
            .SingleOrDefaultAsync(character => character.Id == opponentId) ??
            throw new Exception($"Opponent with Id: {opponentId} not found.");

        return opponent;
    }

    private string ApplyDamage(Character attacker, Character opponent, int damage)
    {
        // do not apply damage < 0
        damage = Math.Max(0, damage);

        if (damage > 0)
        {
            opponent.HitPoints -= damage;
        }

        if (opponent.HitPoints <= 0)
        {
            attacker.Victories++;
            opponent.Defeats++;
            return $"The attacker {attacker.Name} (Id: {attacker.Id}) defeated "
                + $"the opponent {opponent.Name}  (Id: {opponent.Id}).";

        }

        return $"The opponent {opponent.Name} (Id: {opponent.Id}) lost {damage} points "
            + $"after an attack by {attacker.Name} (Id: {attacker.Id}).";
    }

    /// <summary>
    /// This is a very simple example of damage calculation logic - in the case of a real RPG game,
    /// complex logic can be created where the result depends on the type of weapon 
    /// and what things and skills the opponent has.
    /// </summary>
    /// <param name="attacker"></param>
    /// <param name="attackerWeapon"></param>
    /// <param name="opponent"></param>
    /// <returns></returns>
    private int CalculateWeaponAttackDamage(Character attacker, Weapon attackerWeapon, Character opponent)
    {
        int opponentDefense =
            (int)(_random.NextDouble() * (opponent.Defense * (1 - MinDefenseFactor)) +
            opponent.Defense * MinDefenseFactor);

        int attackerStrength =
            (int)(_random.NextDouble() * (attacker.Strength * (1 - MinStrengthFactor)) +
            attacker.Strength * MinStrengthFactor);

        int damage =
            attackerWeapon.Damage + (int)(attackerStrength * StrengthRelevanceFactor);

        return damage - opponentDefense;
    }

    /// <summary>
    /// This is a very simple example of damage calculation logic - in the case of a real RPG game,
    /// complex logic can be created where the result depends on the type of skill 
    /// and what things and skills the opponent has
    /// </summary>
    /// <param name="attacker"></param>
    /// <param name="attackerSkill"></param>
    /// <param name="opponent"></param>
    /// <returns></returns>
    private int CalculateSkillAttackDamage(Character attacker, Skill attackerSkill, Character opponent)
    {
        double defenseFactor = _random.NextDouble() * (1 - MinDefenseFactor) + MinDefenseFactor;
        int opponentDefense = (int)(opponent.Defense * defenseFactor);

        double strengthFactor = _random.NextDouble() * (1 - MinStrengthFactor) + MinStrengthFactor;
        int attackerStrength = (int)(attacker.Strength * strengthFactor);

        double intelligenceFactor = _random.NextDouble() * (1 - MinIntelligenceFactor) +
            MinIntelligenceFactor;
        int attackerIntelligence = (int)(attacker.Intelligence * intelligenceFactor);
        int opponentIntelligence = (int)(opponent.Intelligence * intelligenceFactor);
        int intelligencePoints =
            Math.Clamp(attackerIntelligence - opponentIntelligence, 0, attackerIntelligence);

        int damage = (int)(attackerSkill.Complexity * SkillComplexityRelevanceFactor) +
            intelligencePoints +
            (int)(attackerStrength * StrengthRelevanceFactor);

        return damage - opponentDefense;
    }

    #region AutomaticFightExampleLogic

    private void ConductAFightBetweenCharacters(List<string> log, List<Character> charactersInvolved)
    {
        bool oneCharacterDefeated = false;
        var random = new Random();

        while (!oneCharacterDefeated)
        {
            foreach (var attacker in charactersInvolved)
            {
                var opponents = charactersInvolved
                                .Where(character => character.Id != attacker.Id).ToList();

                var randomOpponent = opponents[random.Next(opponents.Count)];

                AttackOpponentDuringFight(attacker, randomOpponent, log, random);

                // simple logic to end the death match
                if (randomOpponent.HitPoints <= 0)
                {
                    log.Add($"Character {randomOpponent.Name} (Id: {randomOpponent.Id}) has been defeated.");
                    log.Add($"End of the fight. Character {attacker.Name}"
                        + $" (Id: {attacker.Id}) has won and has {attacker.HitPoints} HP left.");

                    oneCharacterDefeated = true;
                    break;
                }
            }
        }
    }

    private void AttackOpponentDuringFight(Character attacker, Character opponent, List<string> log, Random random)
    {
        var damage = 0;
        var attackName = string.Empty;

        var useSkill = random.NextDouble() >= 0.5d; // attack with weapon or skill?

        if (useSkill && attacker.Skills is not null && attacker.Skills.Count > 0)
        {
            var skill = attacker.Skills[random.Next(attacker.Skills.Count)];
            attackName = skill.Name;
            damage = CalculateSkillAttackDamage(attacker, skill, opponent);
        }
        else if (!useSkill && attacker.Weapons is not null && attacker.Weapons.Count > 0)
        {
            var weapon = attacker.Weapons[random.Next(attacker.Weapons.Count)];
            attackName = weapon.Name;
            damage = CalculateWeaponAttackDamage(attacker, weapon, opponent);
        }
        else
        {
            log.Add($"Character: {attacker.Name} (Id: {attacker.Id})"
            + " was unable to attack anyone because he has no weapons or skills.");
            return;
        }

        var attackLog = ApplyDamage(attacker, opponent, damage);
        log.Add($"Attack using: {attackName} with damage: {damage} - " + attackLog);
    }

    /// <summary>
    /// restart characters hit points
    /// next death mach can have different result (some things are randomized 
    /// and characters can collect more skills and items between fights)
    /// </summary>
    /// <param name="characters"></param>
    private void ResetHitPointsAndCountFight(List<Character> characters)
    {
        characters.ForEach(character =>
        {
            character.Fights++;
            character.HitPoints = DefaultHitPoints;
        });
    }

    #endregion AutomaticFightExampleLogic
}
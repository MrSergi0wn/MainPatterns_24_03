namespace SpaceBattle.Authentication;

public interface IAuthenticationService
{
    int SpaceBattleRegister(string usersJwtToken, int[] battleUserIds);
    string GetUserAuthenticationJwt(int userId, string userName);
    string GetStarBattleAuthorizationJwt(int battleId, string token);
    bool ValidateToken(string token);
}
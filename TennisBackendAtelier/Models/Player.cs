namespace TennisBackendAtelier.Models;

public record Player(
    int Id,
    string Firstname,
    string Lastname,
    string Shortname,
    string Sex,
    Country Country,
    string Picture,
    PlayerData Data);

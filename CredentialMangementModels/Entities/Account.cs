namespace CredentialMangementModels.Entities
{
    public class Account
    {
        public int Number { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public DateTime Date { get; init; }

        public override string ToString() => $"Number: {Number}, Username: {Username}, Password: {Password}, Date: {DateOnly.FromDateTime(Date)}";
    }
}

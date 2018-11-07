namespace EM.Calc.DB
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public override string TableName { get => "Users"; }

        public override string Fields { get => "Login, BirthDay, Sex"; }
    }
}

namespace Lab1_TH_NGOCHIHAO.DTOS.User
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public DateTime Birthday { get; set; }

        public string Role { get; set; }

        internal object Select(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}

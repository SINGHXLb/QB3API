namespace QB3API.Model.Security
{
    
    public class UserTokens
    {
        public UserTokens() 
        {
            this.AccessToken= "XXXX";
            this.RefreshToken = "XXXX";
        }
        public string AccessToken
        {
            get;
            set;
        }
      
        public DateTime ValidTill
        {
            get;
            set;
        }
        public string RefreshToken
        {
            get;
            set;
        }
      
    }
}

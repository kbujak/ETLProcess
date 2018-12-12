using System.Collections.Generic;

namespace ETL.Model
{
    public class CommentResult
    {

        public CommentResult(IList<GuestComment> guestComments, IList<UserComment> userComments)
        {
            GuestComments = guestComments;
            UserComments = userComments;
        }

        public IList<GuestComment> GuestComments { get; set; }

        public IList<UserComment> UserComments { get; set; }
    }    
}

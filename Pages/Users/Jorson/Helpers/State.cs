using System;
using System.Collections.Generic;

namespace ExoKomodo.Pages.Users.Jorson.Helpers
{
    public class State
    {
        public string Id { get; set; }
        public IList<string> NextStates { get; set; }
    }
}
using System.Collections.Generic;

namespace DOTZ.Desafio.MStest.Base
{
    public class ErrorsValidate
    {
        public StateDto Errors { get; set; }
    }
    public class StateDto
    {
        public List<string> State { get; set; }
        public List<string> Password { get; set; }
        public List<string> Description { get; set; }
    }
}

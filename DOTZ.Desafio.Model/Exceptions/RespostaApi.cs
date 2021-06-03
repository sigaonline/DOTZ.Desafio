using System;
using System.Collections.Generic;
using System.Text;

namespace DOTZ.Desafio.Model.Exceptions
{
    public class RespostaApi<T>
    {
        public T dados { get; set; }
        public bool erro { get; set; }
        public string mensagem { get; set; }
    }
}

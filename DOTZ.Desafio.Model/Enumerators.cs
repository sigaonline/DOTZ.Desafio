using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DOTZ.Desafio.Model
{
    public enum UserRoles
    {
        [Description("Usuário")]
        User = 1,
        [Description("Administrador")]
        Admin = 2
    }

    public enum ExceptionMessages
    {
        [Description("Usuário não existe na base de dados!")] UserNotFound,
        [Description("Usuário já existe na base de dados!")] UserNFound,
        [Description("Já existe um endereço cadastrado para o usuário!")] LocationFound,
        [Description("Produto não existe na base de dados!")] ProductNotFound,

    }
}

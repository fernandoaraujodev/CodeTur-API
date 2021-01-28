using CodeTur.Comum.Enum;
using CodeTur.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Testes.Entidades
{
    class UsuarioTestes
    {
        public void Usuario()
        {
            var usuario = new Usuario("", "", "", EnTipoUsuario.Admin);
        }
    }
}

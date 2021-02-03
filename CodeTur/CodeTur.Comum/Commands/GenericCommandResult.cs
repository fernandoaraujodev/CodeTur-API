using System;
using System.Collections.Generic;
using System.Text;

namespace CodeTur.Comum.Commands
{
    class GenericCommandResult
    {
        public bool Sucesso { get; private set; }
        public string Mensagem { get; private set; }
        public object Data { get; private set; }

    }
}

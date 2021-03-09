using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessoSeletivoTotvs.Infra.Data.Scripts
{
    public class DatabaseScripts
    {
        public static readonly string CREATE_USER_REPORT_DATABASE =
        @"CREATE TABLE Usuario (
        Id INTEGER not null, 
        Name VARCHAR(50) NOT NULL,
        Senha VARCHAR(50) NOT NULL,
        Email VARCHAR(50) NOT NULL,
        Created DATETIME NOT NULL,
        Modified DATETIME NOT NULL,
        LastLogin DATETIME NOT NULL,
        Perfis VARCHAR(50), NOT NULL   
        PRIMARY KEY(Id)        
        );";

        public static readonly string INSERT_DATA_INTO_USER_REPORT_DATABASE =
            $@"INSERT INTO Usuario (Id,Name, Senha, Email, Created, Modified, LastLogin)
            VALUES  ('{ Guid.NewGuid().ToString() }','Alessandra Gomes', '123456789', AlessandraGomes@teste.com, '2012/02/02', '2015/04/02', '2020/05/02', usuario),
                    ('{ Guid.NewGuid().ToString() }','Bruno Silva', '123456789', BrunoSilva@teste.com, '2012/02/02', '2015/04/02', '2020/05/02', administrador),
                    ('{ Guid.NewGuid().ToString() }','Alex Gomes', '123456789', AlexGomes@teste.com, '2012/02/02', '2015/04/02', '2020/05/02', gerente);";
    

    }
}

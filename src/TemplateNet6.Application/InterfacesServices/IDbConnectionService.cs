using System;
using System.Data;

namespace TemplateNet6.Application.InterfacesServices
{
    public interface IDbConnectionService
    {
        IDbConnection? OpenConnection();
    }
}

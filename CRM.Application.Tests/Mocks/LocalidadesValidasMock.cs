using Storm.Tecnologia.Gov.Interfaces;
using Storm.Tecnologia.Gov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Tests.Mocks
{
    public class LocalidadesValidasMock : ILocalidadesService
    {
        private EstadoModel estado;
        public Task<EstadoModel> GetEstado(string UF)
        {
            estado = new EstadoModel()
            {
                regiao = new RegiaoEstadoModel() { nome = "Sudeste", sigla = "SU", id = 1 },
                nome = "Minas Gerais",
                sigla = "MG"
            };

            return Task.FromResult(estado);
        }

        public Task<List<EstadoModel>> GetEstados()
        {
            throw new NotImplementedException();
        }
    }
}

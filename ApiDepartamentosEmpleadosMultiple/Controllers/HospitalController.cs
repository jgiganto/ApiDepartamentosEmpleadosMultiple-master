using ApiDepartamentosEmpleadosMultiple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiDepartamentosEmpleadosMultiple.Controllers
{
    public class HospitalController : ApiController
    {
        ModeloHospital modelo;
        public HospitalController()
        {
            this.modelo = new ModeloHospital();
        }

        [HttpGet]
        [Route("api/MostrarDepartamentos")]
        public List<DEPT> MostrarDepartamentos()
        {
            return modelo.GetDepartamentos();
        }

        [HttpGet]
        [Route("api/EmpleadosDept")]
        //http:/localhost:52896/api/EmpleadosDept/?deptnos=20&deptnos=30
        public List<EMP> EmpleadosDepartamentos([FromUri]List<int?> deptnos)
        {
            if (deptnos != null)
            {
                return modelo.GetEmpleadosDepartamento(deptnos);
            }
            else { return null; }
        }

        [HttpPost]
        [Route("api/Incremento")]
        public List<EMP> IncrementoSalarial([FromUri]List<int?> empno,int? incremento)
        {
            if(empno != null && incremento != null)
            {
                return modelo.IncrementoSalarial(empno, incremento);
            }
            else { return null; }
            
        }
    }
}

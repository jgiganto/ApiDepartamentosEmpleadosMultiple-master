using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiDepartamentosEmpleadosMultiple.Models
{
    public class ModeloHospital
    {
        ContextoHospital contexto;
        public ModeloHospital()
        {
            this.contexto = new ContextoHospital();
        }
        public List<DEPT> GetDepartamentos()
        {
            var consulta = from datos in contexto.DEPT
                           select datos;
            return consulta.ToList();
        }
        public List<EMP> GetEmpleadosDepartamento(List<int?> deptnos)
        {
            var consulta = from datos in contexto.EMP
                           where deptnos.Contains(datos.DEPT_NO)
                           select datos;
            return consulta.ToList();
        }

        public List<EMP> IncrementoSalarial(List<int?> empno,int? incremento)
        {
            var consulta = from datos in contexto.EMP
                           where empno.Contains(datos.EMP_NO)
                           select datos;
            foreach(var emp in consulta)
            {
                emp.SALARIO += incremento;
            }
            contexto.SaveChanges();
            return consulta.ToList();
        }
    }
}
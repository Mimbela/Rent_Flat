using RepositorioRentFlat.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepositorioRentFlat.Repositories
{
  public  interface IRepository
    {
        //-----------------------------------------------
        List<Tipos_Vivienda> GetTiposViviendas();
        Tipos_Vivienda BuscarTipoVivienda(int id);
        void ModificarTipoVivienda(Tipos_Vivienda modelo);
        void InsertarTipoViviendas(Tipos_Vivienda modelo);
        void EliminarTipoViviendas(int id);

        //-----------------------------------------------
        List<Costas> GetNombreCostas();
        Costas BuscarCosta(int id);
        void ModificarCosta(Costas modelo);
        void InsertarCosta(Costas modelo);
        void EliminarCosta(int id);

        //--------------------------------------------USUARIOS
        List<Usuarios> GetUsuarios();
        Usuarios BuscarUsuario(int id);
        void ModificarUsuario(Usuarios modelo);
        void InsertarUsuarios(Usuarios modelo);
        void EliminarUsuario(int id);
        //--------------------------------------------VIVIENDAS
        List<Viviendas> GetViviendas();
        List<Viviendas> GetViviendasByFilter(int TipoVivienda, int Costa, int Banios, int Habitaciones);
        Viviendas BuscarViviendas(int id);
        void ModificarVivienda(Viviendas modelo);
        void InsertarViviendas(Viviendas modelo);
        void EliminarViviendas(int id);
        //-------------------------------------------LOGIN-VALIDACIONES
        Usuarios ExisteEmpleado(String login, String password);
        List<Usuarios> GetEmpleadosSubordinaros(int director);
        Usuarios BuscarEmpleado(String login);
        






    }

}

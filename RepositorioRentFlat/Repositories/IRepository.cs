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
        Dictionary<int, String> ComboRolUsuario();

        //--------------------------------------------VIVIENDAS
        List<Viviendas> GetViviendas();
        List<VIVIENDASPORFILTRO_Result> GetViviendasByFilter(int TipoVivienda, int Costa, int Banios, int Habitaciones,int Cod_Casa, int Cod_Cliente);
        Viviendas BuscarViviendas(int id);
        void ModificarVivienda(Viviendas modelo);
        int InsertarViviendas(Viviendas modelo);
        void EliminarViviendas(int id);
        int InsertarImagen(Galeria_Fotos model);
        //-------------------------------------------LOGIN-VALIDACIONES
        Usuarios ExisteEmpleado(String login, String password);
        List<Usuarios> GetEmpleadosSubordinaros(int director);
        Usuarios BuscarEmpleado(String login);


        //----------------------------INDEX
        List<VISTATODOSCLIENTES> PaginarClientes(int indice, ref int totalregistros);
        






    }

}

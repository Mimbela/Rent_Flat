using RepositorioRentFlat.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioRentFlat.Repositories
{
    public class Repository : IRepository
    {
        EntidadRenting entidad;



        public Repository(EntidadRenting entidad)
        {
            this.entidad = entidad;
        }

        public Costas BuscarCosta(int id)
        {
            var consulta = from datos in entidad.Costas
                           where datos.Cod_Provincia == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public Usuarios BuscarEmpleado(string login)
        {
            var consulta = from datos in entidad.Usuarios
                           where datos.Login == login
                           select datos;
            return consulta.FirstOrDefault();
        }

        public Tipos_Vivienda BuscarTipoVivienda(int id)
        {
            var consulta = from datos in entidad.Tipos_Vivienda
                           where datos.Cod_tipo_vivienda == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public Usuarios BuscarUsuario(int id)
        {
            var consulta = from datos in entidad.Usuarios
                           where datos.Cod_usuario == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public Viviendas BuscarViviendas(int id)
        {
            var consulta = from datos in entidad.Viviendas
                           where datos.Cod_casa == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void EliminarCosta(int id)
        {
            Costas costas = this.BuscarCosta(id);
            this.entidad.Costas.Remove(costas);
            this.entidad.SaveChanges();
        }

        public void EliminarTipoViviendas(int id)
        {

            Tipos_Vivienda tipos = this.BuscarTipoVivienda(id);
            this.entidad.Tipos_Vivienda.Remove(tipos);
            this.entidad.SaveChanges();
        }

        public void EliminarUsuario(int id)
        {

            Usuarios usuarios = this.BuscarUsuario(id);
            this.entidad.Usuarios.Remove(usuarios);
            this.entidad.SaveChanges();
        }

        public void EliminarViviendas(int id)
        {

            Viviendas viviendas = this.BuscarViviendas(id);
            this.entidad.Viviendas.Remove(viviendas);
            this.entidad.SaveChanges();
        }

        public Usuarios ExisteEmpleado(string login, string password)
        {
            var consulta = from datos in entidad.Usuarios
                           where datos.Login == login
                           && datos.Password == password
                           select datos;
            return consulta.FirstOrDefault();
        }

        public List<Usuarios> GetEmpleadosSubordinaros(int director)
        {
            var consulta = from datos in entidad.Usuarios
                           where datos.DIR == director
                           select datos;

            if (consulta.Count()==0)
            {
                return null;
            }
            else
            {
                return consulta.ToList();
            }
            
        }

        public List<Costas> GetNombreCostas()
                {
                    return this.entidad.Costas.ToList();
                }
        

      
         public List<Tipos_Vivienda> GetTiposViviendas()
                {
                    return this.entidad.Tipos_Vivienda.ToList();
                }

        public List<Usuarios> GetUsuarios()
        {
            return this.entidad.Usuarios.ToList();
        }

        public List<Viviendas> GetViviendas()
        {
            return this.entidad.Viviendas.ToList();
        }

        public List<Viviendas> GetViviendasByFilter(int TipoVivienda, int Costa, int Banios, int Habitaciones)
        {

            List<Viviendas> listaViviendas = this.entidad.Viviendas.Where(x => x.Cod_Provincia == Costa || x.Cod_TipoVivienda == TipoVivienda || x.Num_banios == Banios || x.Num_habitaciones == Habitaciones).ToList();

            return listaViviendas;
        }

        public void InsertarCosta(Costas modelo)
        {
            Costas cost = new Costas();
            cost.Cod_Provincia = modelo.Cod_Provincia;
            cost.Foto = modelo.Foto;
            cost.NombreProvincia = modelo.NombreProvincia;
            this.entidad.Costas.Add(cost);
            this.entidad.SaveChanges();
        }

        public void InsertarTipoViviendas(Tipos_Vivienda modelo)
        {
            Tipos_Vivienda tipo = new Tipos_Vivienda();
            tipo.Cod_tipo_vivienda = modelo.Cod_tipo_vivienda;
            tipo.Descripcion = modelo.Descripcion;
            this.entidad.Tipos_Vivienda.Add(tipo);
            this.entidad.SaveChanges();
        }

        public void InsertarUsuarios(Usuarios modelo)
        {
            Usuarios usu = new Usuarios();
            usu.Apellido = modelo.Apellido;
            usu.DIR = modelo.DIR;
            
            usu.Email = modelo.Email;
            usu.Login = modelo.Login;
            usu.Mostrar_info_contacto = modelo.Mostrar_info_contacto;
            usu.Nombre = modelo.Nombre;
            usu.Password = modelo.Password;
            usu.Perfil = modelo.Perfil;
            usu.Telefono = modelo.Telefono;

            this.entidad.Usuarios.Add(usu);
            this.entidad.SaveChanges();


        }

        public void InsertarViviendas(Viviendas modelo)
        {
            Viviendas v = new Viviendas();
            v.Ciudad = modelo.Ciudad;
            v.Codigo_Posta = modelo.Codigo_Posta;
            v.Cod_casa = modelo.Cod_casa;
            v.Cod_Provincia = modelo.Cod_Provincia;
            v.Descripcion = modelo.Descripcion;
            v.Garaje = modelo.Garaje;
            v.IdCliente = modelo.IdCliente;
            v.Num_banios = modelo.Num_banios;
            v.Num_habitaciones = modelo.Num_habitaciones;
            v.Tamanio_vivienda = modelo.Tamanio_vivienda;
            v.Ubicacion = modelo.Ubicacion;

            this.entidad.Viviendas.Add(v);
            this.entidad.SaveChanges();

        }


        public void ModificarCosta(Costas modelo)
        {
            //Costas costa = (from x in entidad.Costas
            //               where x.Cod_Provincia == c.Cod_Provincia
            //               select x).FirstOrDefault();

            //Costas cost = this.entidad.Costas.Where(z => z.Cod_Provincia == c.Cod_Provincia).FirstOrDefault();

            Costas cost = this.entidad.Costas.Single(z => z.Cod_Provincia == modelo.Cod_Provincia);
            cost.NombreProvincia = modelo.NombreProvincia;
            cost.Foto = modelo.Foto;

            this.entidad.SaveChanges();

        }

        public void ModificarTipoVivienda(Tipos_Vivienda modelo)
        {
            Tipos_Vivienda tipo = this.entidad.Tipos_Vivienda.Single(z => z.Cod_tipo_vivienda == modelo.Cod_tipo_vivienda);
            tipo.Descripcion = modelo.Descripcion;
          

            this.entidad.SaveChanges();
        }

        public void ModificarUsuario(Usuarios modelo)
        {
            Usuarios tipo = this.entidad.Usuarios.Single(z => z.Cod_usuario == modelo.Cod_usuario);
            tipo.Apellido = modelo.Apellido;
            tipo.DIR = modelo.DIR;
            tipo.Email = modelo.Email;
            tipo.Login = modelo.Login;
            tipo.Mostrar_info_contacto = modelo.Mostrar_info_contacto;
            tipo.Nombre = modelo.Nombre;
            tipo.Password = modelo.Password;
            tipo.Telefono = modelo.Telefono;
            tipo.Perfil = modelo.Perfil;

            this.entidad.SaveChanges();

        }

        public void ModificarVivienda(Viviendas modelo)
        {
            Viviendas tipo = this.entidad.Viviendas.Single(z => z.Cod_casa == modelo.Cod_casa);
            tipo.Ciudad = modelo.Ciudad;
            tipo.Codigo_Posta = modelo.Codigo_Posta;
            tipo.Cod_Provincia = modelo.Cod_Provincia;
            tipo.Descripcion = modelo.Descripcion;
            tipo.Garaje = modelo.Garaje;
            tipo.IdCliente = modelo.IdCliente;
            tipo.Num_banios = modelo.Num_banios;
            tipo.Num_habitaciones = modelo.Num_banios;
            tipo.Tamanio_vivienda = modelo.Tamanio_vivienda;
            tipo.Ubicacion = modelo.Ubicacion;

            this.entidad.SaveChanges();
        }
    }
}

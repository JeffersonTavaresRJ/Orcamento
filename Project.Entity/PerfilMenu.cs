﻿namespace Project.Entity
{
    public class PerfilMenu
    {
        public int IdPerfil { get; set; }
        public int IdMenu { get; set; }
        //aqui embaixo posso adicionar mais colunas, como por exemplo, status..

        public virtual Perfil Perfil { get; set; }
        public virtual Menu Menu { get; set; }
    }
}

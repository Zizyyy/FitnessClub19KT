//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnessClub19KT.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientService
    {
        public int IdClientService { get; set; }
        public int IdClient { get; set; }
        public int IdService { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual Service Service { get; set; }
    }
}
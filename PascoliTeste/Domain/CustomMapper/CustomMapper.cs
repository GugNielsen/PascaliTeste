//using DapperExtensions.Mapper;

//namespace DataAcecces.CustomMapper
//{
//    public class CustomMapper<T> : ClassMapper<T> where T : class
//    {
//        public CustomMapper()
//        {
//            // Configurações padrão para todas as entidades
//            Map(x => x.GetType().GetProperty("Id")).Key(KeyType.Guid);
//            Table(typeof(T).Name + "s");
//            AutoMap();
//        }
//    }
//}

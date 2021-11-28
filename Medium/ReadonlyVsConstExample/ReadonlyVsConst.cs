namespace ReadonlyVsConstExample
{
    public class ReadonlyVsConst
    {
        public readonly DemoEntity _memberEntity = new DemoEntity() { Id = 10 };

        public const int SuccessStatusCode = 200;

        public ReadonlyVsConst()
        {
            Console.WriteLine(SuccessStatusCode);

            _memberEntity = new DemoEntity() { Id = 5 };
            _memberEntity = new DemoEntity() { Id = 6 };
            Console.WriteLine(_memberEntity.Id);
        }


        public static readonly DemoEntity _staticEntity = new DemoEntity() { Id = 20 };

        static ReadonlyVsConst()
        {
            _staticEntity = new DemoEntity() { Id = 25 };
        }
    }

    public class DemoEntity
    {
        public int Id { get; set; }
    }
}

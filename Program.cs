namespace L20250218
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Engine.Instance.InitScene();
            Engine.Instance.Load(Engine.Instance.scenes[0]);
            Engine.Instance.Run();
        }
    }
}

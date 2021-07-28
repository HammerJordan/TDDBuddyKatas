namespace CharacterCopy.Kata
{
    public class Copier
    {
        private readonly ISource iSource;
        private readonly IDestination iDestination;

        public Copier(ISource iSource, IDestination iDestination)
        {
            this.iSource = iSource;
            this.iDestination = iDestination;
        }
    }
}
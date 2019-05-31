namespace Svrf.Models.Http
{
    public class SingleMediaApiResponse
    {
        public bool Success { get; internal set; }
        public Media.Media Media { get; internal set; }

        public override bool Equals(object obj)
        {
            var other = obj as SingleMediaApiResponse;

            if (other == null)
            {
                return false;
            }

            return Success == other.Success && Media.Equals(other.Media);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Success.GetHashCode() * 397) ^ (Media != null ? Media.GetHashCode() : 0);
            }
        }
    }
}

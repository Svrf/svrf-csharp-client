namespace Svrf.Models.Media
{
    public class MediaMetadata
    {
        public bool? IsFaceFilter { get; set; }
        public bool? HasBlendShapes { get; set; }
        public bool? RequiresBlendShapes { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as MediaMetadata;

            if (other == null)
            {
                return false;
            }

            return IsFaceFilter == other.IsFaceFilter && HasBlendShapes == other.HasBlendShapes &&
                   RequiresBlendShapes == other.RequiresBlendShapes;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = IsFaceFilter.GetHashCode();
                hashCode = (hashCode * 397) ^ HasBlendShapes.GetHashCode();
                hashCode = (hashCode * 397) ^ RequiresBlendShapes.GetHashCode();
                return hashCode;
            }
        }
    }
}

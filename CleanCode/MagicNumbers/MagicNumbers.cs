
namespace CleanCode.MagicNumbers
{
    public class MagicNumbers
    {
        public enum DocumentStatus
        {
            Draft = 1,
            Lodged = 2
        }

        public void ApproveDocument(DocumentStatus status)
        {
            if (status == DocumentStatus.Draft)
            {
                // ...
            }
            else if (status == DocumentStatus.Lodged)
            {
                // ...
            }
        }

        public void RejectDoument(DocumentStatus status)
        {
            switch (status)
            {
                case DocumentStatus.Draft:
                    // ...
                    break;
                case DocumentStatus.Lodged:
                    // ...
                    break;
            }
        }
    }
}

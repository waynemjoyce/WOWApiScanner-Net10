using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WOWAuctionApi_Net10
{
    public class AuctionEvent
    {
        public event AuctionRetrievedEventHandler? AuctionRetrieved;

        public delegate void AuctionRetrievedEventHandler(object sender, AuctionEventArgs e);

        protected virtual void OnAuctionRetrieved(AuctionEventArgs e)
        {
            AuctionRetrievedEventHandler handler = AuctionRetrieved;
            handler?.Invoke(this, e);
        }

        public void DoAuctionProcess(string accessToken, Realm r)
        {
            HttpStatusCode statusCode = new HttpStatusCode();
            string lastModified = String.Empty;
            AuctionFileContents afc;

            //Process the auction
            afc = API_Blizzard.GetAuctionsFromAPI(accessToken, r, out statusCode, out lastModified);


            if ((afc != null) && (afc.auctions != null))
            {
                //Raise an event once we're done
                AuctionEventArgs aucArgs = new AuctionEventArgs();
                aucArgs.Auctions = afc;
                aucArgs.RealmId = r.RealmId.Value;
                aucArgs.StatusCode = statusCode;
                aucArgs.LastModified = lastModified;
                aucArgs.RealmObject = r;
                r.LastModified = lastModified;

                //OnAuctionRetrieved(aucArgs);
                AuctionRetrieved?.Invoke(this, aucArgs);  
            }
        }
    }

    public class AuctionEventArgs : EventArgs
    {
        public int RealmId { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public AuctionFileContents Auctions { get; set; }

        public Realm RealmObject { get; set; }

        public string LastModified { get; set; }
    }
}

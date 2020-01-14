using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using CommunitySite.Models;
using System.Globalization;

namespace CommunitySite.Repositories
{
    public class PlacesRepo
    {
        private static List<Place> places = new List<Place>();
        public PlacesRepo()
        {
            if (PlacesRepo.places.Count == 0)
            {
                Place place = new Place();
                place.Name = "O of U";
                place.Img = "https://conferences.uoregon.edu/sites/conferences1.uoregon.edu/files/featured_banners/EMU--023--Lease-Crutcher-Lewis.jpg";
                place.Map = "https://www.google.com/maps/place/1793+Columbia+St,+Eugene,+OR+97403/@44.0400683,-123.068043,3a,75y,84.73h,90t/data=!3m7!1e1!3m5!1sHnKMG3ZJ3t6EhrrJ8ML-Lw!2e0!6s%2F%2Fgeo0.ggpht.com%2Fcbk%3Fpanoid%3DHnKMG3ZJ3t6EhrrJ8ML-Lw%26output%3Dthumbnail%26cb_client%3Dsearch.gws-prod.gps%26thumb%3D2%26w%3D360%26h%3D120%26yaw%3D84.73385%26pitch%3D0%26thumbfov%3D100!7i13312!8i6656!4m5!3m4!1s0x54c11e310dcb743f:0x6c09ef6d9efdc8db!8m2!3d44.0400723!4d-123.0679826";
                place.DateAdded = DateTime.Now;
                place.Location = "Main Conference Room at 1585 E 13th Ave, Eugene, OR 97403";
                place.Info = "Meeting Here once a year for the big meeting";
                Places.Add(place);

                Place place2 = new Place();
                place2.Name = "LCC";
                place2.Img = "https://lh5.googleusercontent.com/p/AF1QipOZYLtjrspRrR6vzIfyeb8Y0VWQpWiah4HawW-H=w342-h160-k-no";
                place2.Map = "https://www.google.com/maps/uv?hl=en&pb=!1s0x54c11ff3c4035e43:0x84f7c90b66aabcaa!3m1!7e115!4shttps://lh5.googleusercontent.com/p/AF1QipOZYLtjrspRrR6vzIfyeb8Y0VWQpWiah4HawW-H%3Dw427-h200-k-no!5slcc+-+Google+Search&imagekey=!1e10!2sAF1QipOZYLtjrspRrR6vzIfyeb8Y0VWQpWiah4HawW-H&sa=X&ved=2ahUKEwiMoJrMlbnlAhUKvZ4KHWPUBysQoiowCnoECBEQBg";
                place2.DateAdded = DateTime.Now;
                place2.Location = "Reserved entire Library at 4000 E 30th Ave, Eugene, OR 97405";
                place2.Info = "Every Other Important Meeting Will be Here";
                Places.Add(place2);

                Place place3 = new Place();
                place3.Name = "My Place";
                place3.Img = "https://www.incimages.com/uploaded_files/image/970x450/getty_856794670_385651.jpg";
                place3.Map = "https://www.google.com/maps/vt/data=xnDYxFhsecU33r01tkuEFH3hBriK-bFPYiJgO9eClC2ZmWxjQ9b3iqTwJNUlP7edZVGI0iFcN05zhd-ZJtmxucR9kpp8VV9RHdrOaGPCf10ajgfS9AYLWpSr3cu5hHFFO-YRJtdMwsMVzIZvK5KQJsNZE4Al3hpFtZxfeQUEJmlBJsnLsWWv1z7TvYCE_Rpj969SARyFxNQWrZLQqrTKUFeBuMsE7N2umfc9SO2a-dM";
                place3.DateAdded = DateTime.Now;
                place3.Location = "Location given when you sign up";
                place3.Info = "offseason meetings";
                Places.Add(place3);
            }
        }
        public static List<Place> Places => places;


    }
}

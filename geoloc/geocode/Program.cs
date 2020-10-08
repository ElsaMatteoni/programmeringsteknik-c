using geocode.Extensions;
using NGeoNames;
using NGeoNames.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace geocode
{
    class Program
    {
        const string _resourcePath = ".\\Resources\\SE.txt";

        static readonly IEnumerable<ExtendedGeoName> _locationNames;
        static readonly ReverseGeoCode<ExtendedGeoName> _reverseGeoCodingService;
        
        static readonly (double Lat, double Lng) _gavlePosition;
        static readonly (double Lat, double Lng) _uppsalaPosition;

        static readonly IFormatProvider _formatProvider;

        static Program()
        {
            _locationNames = GeoFileReader.ReadExtendedGeoNames(_resourcePath);
            _reverseGeoCodingService = new ReverseGeoCode<ExtendedGeoName>(_locationNames);

            _gavlePosition = (60.674622, 17.141830);
            _uppsalaPosition = (59.858562, 17.638927);

            _formatProvider = CultureInfo.InvariantCulture;
        }

        static void Main(string[] args)
        {
            // 1. Hitta de 10 närmsta platserna till Gävle (60.674622, 17.141830), sorterat på namn.
            Console.WriteLine("1. Gävle");
            Console.WriteLine("--------");
            ListGavlePositions();

            Console.WriteLine();

            // 2. Hitta de 50 närmsta platserna inom 200 km radie till Uppsala (59.858562, 17.638927), sorterat på avstånd.
            Console.WriteLine("2. Uppsala");
            Console.WriteLine("----------");
            ListUppsalaPositions();

            Console.WriteLine();

            // 3. Lista 10 platser baserat på användarinmatning av latitud och longitud.
            Console.WriteLine("3. User");
            Console.WriteLine("-------");

            ListUserPositions(args);

            Console.WriteLine();
            
        }

        static void ListUserPositions(string[] args)
        {
            double lat = double.Parse(args[0], _formatProvider);
            double lng = double.Parse(args[1], _formatProvider);

            var nearestUser = _reverseGeoCodingService.RadialSearch(lat, lng, 10);

            foreach (var position in nearestUser)
            {
                var userDistance = position.DistanceTo(lat, lng);

                Console.WriteLine($"{position.Name}, distance: {userDistance}");
            }
        }

        static void ListUppsalaPositions()
        {
            var radius = 200 * 1000;
            var nearestUppsala = _reverseGeoCodingService.RadialSearch(_uppsalaPosition.Lat, _uppsalaPosition.Lng, radius, 50);

            nearestUppsala = nearestUppsala.OrderBy(x => x.DistanceTo(_uppsalaPosition.Lat, _uppsalaPosition.Lng));

            foreach (var position in nearestUppsala)
            {
                var uppsalaDistance = position.DistanceTo(_uppsalaPosition.Lat, _uppsalaPosition.Lng);

                Console.WriteLine($"{position.Name}, distance to Uppsala: {uppsalaDistance}");
            }
        }

        static void ListGavlePositions()
        {
            var nearestGavle = _reverseGeoCodingService.RadialSearch(_gavlePosition.Lat, _gavlePosition.Lng, 10);

            nearestGavle = nearestGavle.OrderBy(p => p.Name);

            foreach (var position in nearestGavle)
            {
                Console.WriteLine($"{position.Name}, lat: {position.Latitude}, lng: {position.Longitude}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Marvelist.Entities;
using Marvelous;
using Comic = Marvelist.Entities.Comic;
using Series = Marvelist.Entities.Series;

namespace Marvelist.Tests
{
    public static class TestData
    {
        public static List<Series> Series = new List<Series>
        {
            new Series
            {
                Id = 1997,
                Description = "",
                StartYear = 1998,
                EndYear = 2002,
                Rating = "",
                Modified = DateTime.Parse("2013-03-01 19:34:02.0000000"),
                Title = "Captain America (1998 - 2002)",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/80/5130f42b9d86e",
                        Extension = "jpg"
                    }
            },
            new Series
            {
                Id = 16410,
                Description =
                    "There's a new rule in the galaxy: No one touches Earth! No one!! Why has Earth become the most important planet in the Galaxy? That's what the Guardians of the Galaxy are going to find out!! Join the brightest stars in the Marvel universe: Star Lord, Gamora, Drax, Rocket Raccoon, Groot and--wait for it--Iron-Man, as they embark upon one of the most explosive and eye-opening chapters of Marvel NOW! These galactic Avengers are going to discover secrets that will rattle Marvel readers for years to come! Why wait for the movie? It all starts here!",
                StartYear = 2013,
                EndYear = 2099,
                Rating = "Rated T",
                Modified = DateTime.Parse("2015-11-10 08:58:23.0000000"),
                Title = "Guardians of the Galaxy (2013 - Present)",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/80/50ff0e57e9151",
                        Extension = "jpg"
                    }
            }
        };

        public static List<Comic> Comics = new List<Comic>
        {

            new Comic
            {
                Id = 12767,
                IssueNumber = 1,
                Description = "NULL",
                PageCount = 52,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-01-10 06:00:00.0000000"),
                Price = 2.99f,
                Modified = DateTime.Parse("2014-07-30 23:38:53.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12767/captain_america_1998_1?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #1",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/50/5453d58ed033c",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12768,
                IssueNumber = 10,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-10-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2012-11-26 21:24:03.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12768/captain_america_1998_10?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #10",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/1/90/50b3cfbcb05ed",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12769,
                IssueNumber = 11,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-11-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2012-11-26 21:21:06.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12769/captain_america_1998_11?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #11",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/8/d0/50b3cf0b2929a",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12770,
                IssueNumber = 12,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-12-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2012-11-26 21:17:27.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12770/captain_america_1998_12?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #12",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/40/50b3ce29186dc",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12771,
                IssueNumber = 13,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-01-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2012-11-26 20:52:21.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12771/captain_america_1998_13?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #13",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/10/50b3c839405db",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12772,
                IssueNumber = 14,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-02-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2012-11-26 19:47:03.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12772/captain_america_1998_14?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #14",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/f/20/50b3b8ec3fdc5",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12773,
                IssueNumber = 15,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-03-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-09-29 20:48:56.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12773/captain_america_1998_15?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #15",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/8/e0/4e84bc54bb015",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12774,
                IssueNumber = 16,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-04-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-09-29 21:09:49.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12774/captain_america_1998_16?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #16",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/50/4e84c239b41af",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12775,
                IssueNumber = 17,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-05-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-09-29 21:41:53.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12775/captain_america_1998_17?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #17",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/d0/4e84c93533e3e",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12776,
                IssueNumber = 18,
                Description = "NULL",
                PageCount = 52,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-06-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-09-29 21:52:31.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12776/captain_america_1998_18?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #18",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/20/4e84cac06f054",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12777,
                IssueNumber = 19,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-07-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-09-29 22:19:40.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12777/captain_america_1998_19?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #19",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/2/c0/4e84d034062b1",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12778,
                IssueNumber = 2,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-02-10 06:00:00.0000000"),
                Price = 1.99f,
                Modified = DateTime.Parse("2011-10-07 21:47:49.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12778/captain_america_1998_2?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #2",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/3/80/4e8f55213505f",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12779,
                IssueNumber = 20,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-08-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-09-30 22:01:12.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12779/captain_america_1998_20?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #20",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/60/4e861e52dd62a",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12780,
                IssueNumber = 21,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-09-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-09-30 22:34:31.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12780/captain_america_1998_21?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #21",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/a/03/4e8626406b428",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12781,
                IssueNumber = 22,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-10-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-09-30 22:47:48.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12781/captain_america_1998_22?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #22",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/4/00/4e86290e51a89",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12782,
                IssueNumber = 23,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-11-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-03 22:17:01.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12782/captain_america_1998_23?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #23",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/10/4e8a15ed3313e",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12783,
                IssueNumber = 24,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1999-12-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-04 16:58:49.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12783/captain_america_1998_24?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #24",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/20/4e8a191263cdb",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12784,
                IssueNumber = 25,
                Description = "NULL",
                PageCount = 60,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-01-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-03 22:36:29.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12784/captain_america_1998_25?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #25",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/8/a0/4e8a1ba30b527",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12785,
                IssueNumber = 26,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-02-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-04 17:19:35.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12785/captain_america_1998_26?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #26",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/3/20/4e8b1feea9f9d",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12786,
                IssueNumber = 27,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-03-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-04 17:14:49.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12786/captain_america_1998_27?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #27",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/3/30/4e8b216587a01",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12787,
                IssueNumber = 28,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-04-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-04 17:37:49.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12787/captain_america_1998_28?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #28",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/f/03/4e8b265983613",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12788,
                IssueNumber = 29,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-05-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-04 17:46:05.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12788/captain_america_1998_29?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #29",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/4/30/4e8b2947716c8",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12789,
                IssueNumber = 3,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-03-10 06:00:00.0000000"),
                Price = 1.99f,
                Modified = DateTime.Parse("2011-10-11 18:29:18.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12789/captain_america_1998_3?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #3",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/1/50/4e9469c539434",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12790,
                IssueNumber = 30,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-06-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-04 17:54:58.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12790/captain_america_1998_30?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #30",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/40/4e8b2b833d073",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12791,
                IssueNumber = 31,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-07-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-04 21:29:07.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12791/captain_america_1998_31?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #31",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/e0/4e8b4d83564dd",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12792,
                IssueNumber = 32,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-08-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-04 21:33:27.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12792/captain_america_1998_32?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #32",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/8/90/4e8b5fbcbdfcf",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12793,
                IssueNumber = 33,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-09-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-04 22:28:06.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12793/captain_america_1998_33?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #33",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/5/e0/4e8b63034bb33",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12794,
                IssueNumber = 34,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-10-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-05 20:48:50.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12794/captain_america_1998_34?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #34",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/c/40/4e8ca45c14e3e",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12795,
                IssueNumber = 35,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-11-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-05 20:53:48.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12795/captain_america_1998_35?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #35",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/f0/4e8ca7f9a7470",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12796,
                IssueNumber = 36,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2000-12-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-05 21:23:24.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12796/captain_america_1998_36?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #36",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/c/40/4e8caca6c9017",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12797,
                IssueNumber = 37,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-01-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-05 18:54:14.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12797/captain_america_1998_37?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #37",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/f/b0/4e8c8b85eaaa7",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12798,
                IssueNumber = 38,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-02-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-05 20:33:59.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12798/captain_america_1998_38?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #38",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/d/10/4e8c8f780fb2e",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12799,
                IssueNumber = 39,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-03-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12799/captain_america_1998_39?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #39",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/b/90/4bc34c1cb58a1",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12800,
                IssueNumber = 4,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-04-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2014-03-20 19:50:16.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12800/captain_america_1998_4?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #4",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/d/e0/4e94730196175",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12801,
                IssueNumber = 40,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-04-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12801/captain_america_1998_40?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #40",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12802,
                IssueNumber = 41,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-05-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12802/captain_america_1998_41?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #41",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/d0/4bc32782d794e",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12803,
                IssueNumber = 42,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-06-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12803/captain_america_1998_42?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #42",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/8/60/4bc34c03e160c",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12804,
                IssueNumber = 43,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-07-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12804/captain_america_1998_43?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #43",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/1/f0/4bc34befd4ab6",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12805,
                IssueNumber = 44,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-08-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12805/captain_america_1998_44?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #44",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/4/d0/4bc34beabea7e",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12806,
                IssueNumber = 45,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-09-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12806/captain_america_1998_45?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #45",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/5/40/4bc34c3b16022",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12807,
                IssueNumber = 46,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-10-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12807/captain_america_1998_46?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #46",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/5/00/4bc34c31131b1",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12808,
                IssueNumber = 47,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-11-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12808/captain_america_1998_47?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #47",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/40/4bc34c273b8d6",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12809,
                IssueNumber = 48,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("2001-12-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12809/captain_america_1998_48?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #48",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/8/d0/4bc34c0e14c66",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12810,
                IssueNumber = 49,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("2002-01-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12810/captain_america_1998_49?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #49",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/5/e0/4bc34bc693105",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12811,
                IssueNumber = 5,
                Description = "NULL",
                PageCount = 36,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-05-10 06:00:00.0000000"),
                Price = 1.99f,
                Modified = DateTime.Parse("2011-10-11 21:21:52.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12811/captain_america_1998_5?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #5",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/c/c0/4e9492aeb73fb",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12812,
                IssueNumber = 50,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("2002-02-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12812/captain_america_1998_50?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #50",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/b/c0/4bc34ac6d52d2",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12813,
                IssueNumber = 6,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-06-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-11 21:36:48.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12813/captain_america_1998_6?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #6",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/4/10/4e94983351c6d",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12814,
                IssueNumber = 7,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-07-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-12 19:01:15.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12814/captain_america_1998_7?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #7",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/a/00/4e95c563db7b8",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12815,
                IssueNumber = 8,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-08-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("2011-10-07 19:12:35.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12815/captain_america_1998_8?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #8",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/7/10/4e8f36e428b83",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 12816,
                IssueNumber = 9,
                Description = "NULL",
                PageCount = 0,
                SeriesId = 1997,
                Date = DateTime.Parse("1998-09-10 06:00:00.0000000"),
                Price = 0,
                Modified = DateTime.Parse("0001-01-01 00:00:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/12816/captain_america_1998_9?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Captain America (1998) #9",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/1/30/4c699652937a2",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43294,
                IssueNumber = 12,
                Description = "THE TRIAL OF JEAN GREY PART 4!A surprise ally from one character",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-02-26 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-02-24 19:08:53.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43294/guardians_of_the_galaxy_2013_12?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #12",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/3/00/530b8a227209f",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43295,
                IssueNumber = 11,
                Description = "The Guardians of the Galaxy get a reminder of ",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-01-29 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-01-17 21:13:30.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43295/guardians_of_the_galaxy_2013_11?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #11",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/e0/52d98d90d5a55",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43296,
                IssueNumber = 10,
                Description =
                    "Angela and Gamora go hunting.Special guest artist Kevin Maguire (Justice League, Batman Confidential, X-Men)",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-12-31 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-06-02 19:34:47.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43296/guardians_of_the_galaxy_2013_10?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #10",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/00/52b49a5acb634",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43297,
                IssueNumber = 9,
                Description =
                    "INFINITY TIE-IN The Infinity adventure continues as Thanos's rise might lead to the Guardians' fall.",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-12-04 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-05-29 16:40:12.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43297/guardians_of_the_galaxy_2013_9?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #9",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/70/529e02f7b60fd",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43298,
                IssueNumber = 8,
                Description =
                    "INFINITY TIE-IN What will it take for Peter Quill to betray the entire Marvel Universe?And if you don't know Eisner award winning artist Francesco Francavilla yet, you will after this comic!",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-10-30 05:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2013-11-19 22:46:07.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43298/guardians_of_the_galaxy_2013_8?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #8",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/b/d0/51dda5d71e11e",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43299,
                IssueNumber = 7,
                Description =
                    "With the mysterious Angela now on the team and the massive effects of Infinity beginning to rise, the galaxy's most mismatched heroes find themselves at a crossroads.PLUS: All covers feature a special digital variant cover activated by the Marvel AR app.",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-10-15 21:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2016-05-05 11:43:10.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43299/guardians_of_the_galaxy_2013_7?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #7",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/a/e0/5253047922679",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43300,
                IssueNumber = 6,
                Description =
                    "- The blockbuster new series hits hard as Marvel's newest superstar Angela comes right for the Guardians!",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-09-25 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2013-09-26 18:50:23.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43300/guardians_of_the_galaxy_2013_6?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #6",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/2/d0/523227b24d05f",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43301,
                IssueNumber = 5,
                Description =
                    "Spinning out of the dramatic conclusion of Age of Ultron, dimensions collide and Heaven's most fearsome Angel pushes the Guardians back on their heels.",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-07-31 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2013-07-26 20:02:56.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43301/guardians_of_the_galaxy_2013_5?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #5",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/5/d0/51e5a5ea35800",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43302,
                IssueNumber = 4,
                Description =
                    "The biggest surprise hit of the year continues as critically acclaimed artist Sara Pichelli (Ultimate Spider-Man) climbs aboard!Gamora is one the galaxy’s greatest warriors…with a deadly secret that could bring down the entire team.",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-06-26 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2013-06-25 18:55:28.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43302/guardians_of_the_galaxy_2013_4?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #4",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/b/d0/51c8b523dcca4",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43303,
                IssueNumber = 3,
                Description =
                    "As the Guardians first story wraps up, the mysteries leading to the next great Marvel event become clearer.",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-06-12 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2013-06-24 23:22:49.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43303/guardians_of_the_galaxy_2013_3?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #3",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/4/03/51a759230482d",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43304,
                IssueNumber = 2,
                Description =
                    "While London deals with the brutal Badoon invasion, the fate of the Guardians of the Galaxy may have been decided millions of miles away.",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-04-24 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2013-06-19 18:09:25.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43304/guardians_of_the_galaxy_2013_2?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #2",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/2/10/515f25bccfbec",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 43305,
                IssueNumber = 1,
                Description =
                    "There's a new rule in the galaxy: No one touches Earth! No one!! Why has Earth become the most important planet in the Galaxy? That's what the Guardians of the Galaxy are going to find out!! Join the brightest stars in the Marvel universe: Star Lord, Gamora, Drax, Rocket Raccoon, Groot and--wait for it--Iron-Man, as they embark upon one of the most explosive and eye-opening chapters of Marvel NOW! These galactic Avengers are going to discover secrets that will rattle Marvel readers for years to come! Why wait for the movie? It all starts here!",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-03-26 21:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2016-04-13 13:04:50.0000000"),
                Url =
                    "http://marvel.com/comics/issue/43305/guardians_of_the_galaxy_2013_1?utm_campaign=apiRef&utm_source=10a6b522780eb9cc9cbbee50eede9c39",
                Title = "Guardians of the Galaxy (2013) #1",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/9/60/573deeae53730",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 46135,
                IssueNumber = 0,
                Description = "Move over Avengers…the Guardians got this.",
                PageCount = 40,
                SeriesId = 16410,
                Date = DateTime.Parse("2013-02-27 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-08-08 16:51:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/46135/guardians_of_the_galaxy_2013_0.1?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #0.1",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/1/60/569e9908f0291",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 48632,
                IssueNumber = 13,
                Description = "The conclusion of THE TRIAL OF JEAN GREY leaves two teams devastated!",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-03-26 05:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-07-11 20:37:00.0000000"),
                Url =
                    "http://marvel.com/comics/issue/48632/guardians_of_the_galaxy_2013_13?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #13",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/3/03/531f626c24093",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 48633,
                IssueNumber = 14,
                Description = "100th issue ANIVERSARY CELEBRATION!",
                PageCount = 48,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-04-23 06:00:00.0000000"),
                Price = 4.99f,
                Modified = DateTime.Parse("2014-07-14 17:21:38.0000000"),
                Url =
                    "http://marvel.com/comics/issue/48633/guardians_of_the_galaxy_2013_14?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #14",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/c/10/534eebb63a4a7",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 48634,
                IssueNumber = 15,
                Description =
                    "- With the entire galaxy gunning for the Guardians and Peter Quill missing, its time to bring in a little help. Captain Marvel JOINS the Guardians of the Galaxy!",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-05-28 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-07-14 20:34:47.0000000"),
                Url =
                    "http://marvel.com/comics/issue/48634/guardians_of_the_galaxy_2013_15?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #15",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/e/f0/5374f97348967",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 48635,
                IssueNumber = 16,
                Description =
                    "- Starlord on the run from a mysterious new adversary-alone without the aid of the Guardians!",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-06-25 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-07-16 22:00:38.0000000"),
                Url =
                    "http://marvel.com/comics/issue/48635/guardians_of_the_galaxy_2013_16?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #16",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/c0/5399d52d337da",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 48636,
                IssueNumber = 17,
                Description =
                    "With some new faces on the team, it might be time for the Guardians to have a little team-building vacation.Or, you know, they could keep fighting alien warlords and galactic empires. Guess they'll have to plan that team-building retreat for next month.",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-07-30 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-07-30 17:14:47.0000000"),
                Url =
                    "http://marvel.com/comics/issue/48636/guardians_of_the_galaxy_2013_17?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #17",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/b/b0/53cd6af02b25c",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 48637,
                IssueNumber = 18,
                Description =
                    "Original Sin Tie-In! You know you want to know how Star-Lord got back from the Cancerverse. And didn't Nova go in there with him? Guess he's not into the whole no man left behind thing.",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-08-27 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-09-09 17:48:58.0000000"),
                Url =
                    "http://marvel.com/comics/issue/48637/guardians_of_the_galaxy_2013_18?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #18",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/3/c0/5367a942c29e3",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 50978,
                IssueNumber = 20,
                Description = "- The FINAL CHAPTER of what really happened in the Cancerverse!",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-10-29 05:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2015-07-23 20:05:14.0000000"),
                Url =
                    "http://marvel.com/comics/issue/50978/guardians_of_the_galaxy_2013_20?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #20",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/3/00/55b242ad84037",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 51069,
                IssueNumber = 21,
                Description =
                    "- As the Guardians of the Galaxy encounter an entire world full of alien symbiotes, they ask themselves...was allowing Flash Thompson to join their ranks a wise decision? ",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-11-19 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-11-26 15:37:42.0000000"),
                Url =
                    "http://marvel.com/comics/issue/51069/guardians_of_the_galaxy_2013_21?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #21",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/c0/5464eabe99180",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 51163,
                IssueNumber = 22,
                Description =
                    "Part Three of The Planet of the Symbiotes! Now that Venom has led the Guardians to this devastatingly dangerous planet of alien symbiotes, will the team ever trust Flash Thompson again?",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-12-17 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-11-18 17:47:23.0000000"),
                Url =
                    "http://marvel.com/comics/issue/51163/guardians_of_the_galaxy_2013_22?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #22",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/4/00/5491a1de66768",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 51896,
                IssueNumber = 24,
                Description = "The 2nd chapter of the BLACK VORTEX!",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2015-02-11 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2015-02-02 18:29:51.0000000"),
                Url =
                    "http://marvel.com/comics/issue/51896/guardians_of_the_galaxy_2013_24?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #24",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/f/10/54cfb2f5f0b2e",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 51899,
                IssueNumber = 25,
                Description = "Chapter 7 of the BLACK VORTEX!",
                PageCount = 40,
                SeriesId = 16410,
                Date = DateTime.Parse("2015-03-25 05:00:00.0000000"),
                Price = 4.99f,
                Modified = DateTime.Parse("2015-03-13 21:14:52.0000000"),
                Url =
                    "http://marvel.com/comics/issue/51899/guardians_of_the_galaxy_2013_25?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #25",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/30/5503446dc71bf",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 51902,
                IssueNumber = 26,
                Description =
                    "It seems like the Guardians have forgotten something in all the cosmic craziness that's been going on... Oh...that's right...Peter got elected President of Spartax...wait WHAT?! Looks like he's done a GREAT job escaping his father's legacy. Guess he can even screw that up...",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2015-04-22 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2015-04-20 17:28:14.0000000"),
                Url =
                    "http://marvel.com/comics/issue/51902/guardians_of_the_galaxy_2013_26?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #26",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/c/a0/553514e108202",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 51903,
                IssueNumber = 27,
                Description =
                    "Guardians no more? Following the Black Vortex, the Guardians have come into conflict with one another more and more. With rifts forming between them, will their friendship and history be enough to hold the team together?",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2015-05-20 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2015-05-14 20:52:59.0000000"),
                Url =
                    "http://marvel.com/comics/issue/51903/guardians_of_the_galaxy_2013_27?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #27",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/6/c0/5554eab0886b8",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 48638,
                IssueNumber = 19,
                Description =
                    "Last we checked, Star-Lord, Thanos, and Nova were trapped in the Cancerverse...But Star-Lord and Thanos seem to be running around just fine. So what exactly happened to Richard Rider",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2014-09-24 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2014-11-21 22:41:17.0000000"),
                Url =
                    "http://marvel.com/comics/issue/48638/guardians_of_the_galaxy_2013_19?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #19",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/b/03/54173392468cc",
                        Extension = "jpg"
                    }
            },
            new Comic
            {
                Id = 51894,
                IssueNumber = 23,
                Description =
                    "Venom finally takes a trip home! Can't wait to meet its folks. Or...the thing it spawned from...or whatever... But with the symbiote becoming more and more uncontrollable, this may be seriously bad news for the Guardians. I mean...come on guys! Can't they have ONE nice vacation? Always with the monsters and aliens and lasers and stuff...",
                PageCount = 32,
                SeriesId = 16410,
                Date = DateTime.Parse("2015-01-21 06:00:00.0000000"),
                Price = 3.99f,
                Modified = DateTime.Parse("2015-01-13 19:12:06.0000000"),
                Url =
                    "http://marvel.com/comics/issue/51894/guardians_of_the_galaxy_2013_23?utm_campaign=apiRef&utm_source=b197e6f84df3353a20f4011be01958e6",
                Title = "Guardians of the Galaxy (2013) #23",
                Thumbnail =
                    new MarvelImage
                    {
                        Path = "http://i.annihil.us/u/prod/marvel/i/mg/4/20/54b55c72b7896",
                        Extension = "jpg"
                    }
            }
        };

        public static List<ApplicationUser> Users = new List<ApplicationUser>()
        {
            new ApplicationUser {Email = "first@Marvelist", UserName = "first", Id = "1"}
        };
        public static List<UserSeries> UserSeries = new List<UserSeries>();
        public static List<UserComic> UserComics = new List<UserComic>();
    }
}
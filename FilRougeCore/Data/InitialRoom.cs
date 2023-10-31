using FilRougeCore.Models;
using System;


namespace FilRougeCore.Data
{
    public static class InitialRoom
    {
        public static readonly List<Room> completeRooms = new List<Room>()
        {
            new Room{ Id =1, Name ="Salle1", Location = "1er étage - 4 rue tartempion Lille", Activities = new List<Activity>(){
                    new Activity{ Id =2, Name ="Yoga"},
                    new Activity{ Id =3, Name ="Danse"},
                    new Activity{ Id =4, Name ="Zumba"}
                }, Schedules = new List<Schedule>(){
                    new Schedule{ Id =1, RoomId =1, Day="Monday", 
                        OpenTime = new DateTime(1900,1,1, 8, 0, 0), 
                        CloseTime = new DateTime(1900,1,1, 20, 0, 0)
                    },
                    new Schedule{ Id =2, RoomId =1, Day ="Tuesday", 
                        OpenTime = new DateTime(1900,1,1, 8, 0, 0), 
                        CloseTime = new DateTime(1900,1,1, 20, 0, 0)
                    }
                },
                ImageURL = "/images/yoga.PNG"  
            },
            new Room{ Id =2, Name ="Salle2", Location = "RDC - 4 rue tartempion Lille", Activities = new List<Activity>(){
                    new Activity{ Id =1, Name ="Fitness"},
                    new Activity{ Id =5, Name ="Pilates"},
                    new Activity{ Id =6, Name ="Cardio"}
                }, Schedules = new List<Schedule>(){
                    new Schedule{ Id =3, RoomId =1, Day="Monday", 
                        OpenTime = new DateTime(1900,1,1, 8, 0, 0), 
                        CloseTime = new DateTime(1900,1,1, 20, 0, 0)
                    },
                    new Schedule{ Id =4, RoomId =1, Day ="Tuesday", 
                        OpenTime = new DateTime(1900,1,1, 8, 0, 0), 
                        CloseTime = new DateTime(1900,1,1, 20, 0, 0)
                    }
                },
                ImageURL = "/images/fitness.PNG"  }
            };

        public static readonly List<Room> rooms = new List<Room>()
        {
            new Room{ Id =1, Name ="Salle1", Location = "1er étage - 4 rue tartempion Lille", ImageURL = "/images/yoga.PNG"},
            new Room{ Id =2, Name ="Salle2", Location = "RDC - 4 rue tartempion Lille", ImageURL = "/images/fitness.PNG" },
        };

        public static readonly List<Activity> completeActivities = new List<Activity>()
        {
            new Activity{ Id =1, Name ="Fitness", Rooms= new List<Room>(){
                    new Room{ Id = 2} 
                } 
            },
            new Activity{ Id =2, Name ="Yoga", Rooms= new List<Room>(){
                    new Room{Id =1} 
                }
            },
            new Activity{ Id =3, Name ="Danse", Rooms= new List<Room>(){
                    new Room{Id =1} 
                }
            },
            new Activity{ Id =4, Name ="Zumba", Rooms= new List<Room>(){
                    new Room{Id =1} 
                }
            },
            new Activity{ Id =5, Name ="Pilates", Rooms= new List<Room>(){
                    new Room{Id = 2} 
                }
            },
            new Activity{ Id =6, Name ="Cardio", Rooms= new List<Room>(){
                    new Room{Id = 2} 
                }
            }
        }; 
        public static readonly List<Activity> activities = new List<Activity>()
        {
            new Activity{ Id =1, Name ="Fitness"},
            new Activity{ Id =2, Name ="Yoga"},
            new Activity{ Id =3, Name ="Danse"},
            new Activity{ Id =4, Name ="Zumba"},
            new Activity{ Id =5, Name ="Pilates"},
            new Activity{ Id =6, Name ="Cardio"}
        };

        public static readonly List<Schedule> schedules = new List<Schedule>()
        {
            new Schedule{ Id =1, RoomId =1, Day="Monday", 
                OpenTime = new DateTime(1900,1,1, 8, 0, 0), 
                CloseTime = new DateTime(1900,1,1, 20, 0, 0, 0)
            },
            new Schedule{ Id =2, RoomId =1, Day ="Tuesday", 
                OpenTime = new DateTime(1900,1,1, 8, 0, 0), 
                CloseTime = new DateTime(1900,1,1, 20, 0, 0)
            },
            new Schedule{ Id =3, RoomId =1, Day="Monday", 
                OpenTime = new DateTime(1900,1,1, 8, 0, 0), 
                CloseTime = new DateTime(1900,1,1, 20, 0, 0, 0,DateTimeKind.Local)
            },
            new Schedule{ Id =4, RoomId =1, Day ="Tuesday", 
                OpenTime = new DateTime(1900,1,1, 8, 0, 0), 
                CloseTime = new DateTime(1900,1,1, 20, 0, 0)
            }
        };

        public static readonly List<Session> completeSessions = new List<Session>()
        {
            new Session{ Id =1, RoomId=1, 
                StartTime = new DateTime(2023,11,27,8,0,0), 
                EndTime = new DateTime(2023,11,27,9,0,0),
                Users = new List<User>(){
                    new User{ Id = 2,FirstName = "Default",LastName = "User",PhoneNumber = "0202020202",
                        Address = "10 rue tartempion 55555 Turlututu",Email = "defaultuser@email.com",
                        PassWord = "PAss00++",IsAdmin = false
                    }
                },
                Comments = new List<Comment>(){
                    new Comment{ Id =1, UserId = 2, SessionId =1, Message="Message Comment 1 ...", Rating= 2},
                    new Comment{ Id =2, UserId = 2, SessionId =1, Message="Message Comment 2 ...", Rating= 3}
                }
            },
            new Session{ Id =2, RoomId=2, 
                StartTime = new DateTime(2023,11,28,8,0,0), 
                EndTime = new DateTime(2023,11,28,9,0,0),
                Users = new List<User>(){
                    new User{ Id = 2,FirstName = "Default",LastName = "User",PhoneNumber = "0202020202",
                        Address = "10 rue tartempion 55555 Turlututu",Email = "defaultuser@email.com",
                        PassWord = "PAss00++",IsAdmin = false}
                },
                Comments = new List<Comment>(){
                    new Comment{ Id =3, UserId = 2, SessionId =2, Message="Message Comment 3 ...", Rating= 4},
                    new Comment{ Id =4, UserId = 2, SessionId =2, Message="Message Comment 4 ...", Rating= 5}
                }
            }
        };
        public static readonly List<Session> sessions = new List<Session>()
        {
            new Session{ Id =1, RoomId=1, 
                StartTime = new DateTime(2023,11,27,8,0,0), 
                EndTime = new DateTime(2023,11,27,9,0,0)
            },
            new Session{ Id =2, RoomId=2, 
                StartTime = new DateTime(2023,11,28,8,0,0), 
                EndTime = new DateTime(2023,11,28,9,0,0)
            }
        };

        public static readonly List<Comment> comments = new List<Comment>()
        {
            new Comment{ Id =1, UserId = 2, SessionId =1, Message="Message Comment 1 ...", Rating= 2},
            new Comment{ Id =2, UserId = 2, SessionId =1, Message="Message Comment 2 ...", Rating= 3},
            new Comment{ Id =3, UserId = 2, SessionId =2, Message="Message Comment 3 ...", Rating= 4},
            new Comment{ Id =4, UserId = 2, SessionId =2, Message="Message Comment 4 ...", Rating= 5}
        };
    }
}

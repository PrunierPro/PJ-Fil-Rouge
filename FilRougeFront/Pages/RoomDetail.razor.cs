using FilRougeFront.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace FilRougeFront.Pages
{
    public partial class RoomDetail
    {
#nullable disable
        [Inject]
        public IRoomService RoomService { get; set; }
#nullable enable


    }
}

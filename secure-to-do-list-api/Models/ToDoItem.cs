using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace secure_to_do_list_api.Models
{
    public class ToDoItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("isCompleted")]
        public bool IsCompleted { get; set; }

    }
}

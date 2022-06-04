using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class JsonForm
{

    [Newtonsoft.Json.JsonProperty("closure_parametr")]
    public string ClosureParametr { get; set; }
    [Newtonsoft.Json.JsonProperty("time")]
    public float Time { get; set; }
    [Newtonsoft.Json.JsonProperty("array_points")]
    public List<string> ArrayPoints { get; set; }
}

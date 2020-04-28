namespace Logging_Performance_Test___Core_Library___FS

open Logging_Performance_Test___Core_Library
open System.Runtime.CompilerServices

type Logger() =
    let messages = System.Collections.Generic.List<string>(10000);

    member this.Log(level : LoggerLevel, msg : string) =
        messages.Add(msg)

    member this.Log(level : LoggerLevel, obj : 'a) =
        messages.Add(obj.ToString())


    interface ILogger with
        member this.Log(level : LoggerLevel, msg : string) =
            messages.Add(msg)

        member this.Log(level : LoggerLevel, obj : 'a) =
            messages.Add(obj.ToString())
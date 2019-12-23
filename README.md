# TaskTimerPattern
This example demonstrates an approximation alternative to the .NET Framework Timer, built with TLP.

This can be useful for periodic polling scenarios, where the period accuracy is not so important. This implementation might drift a few milliseconds in every period, because it is not based on time based activation but rather on Tasks and measured completion time.

Another significant difference is that this implementation is not strictly periodic.

If the execution of one iteration takes longer than the period duration to complete, the next iteration will start after the completion. This was intentional, to avoid multiple threads accessing the same resource.

Because no Timer resources are used and no blocking calls are made, there are no resource considerations when scaling up.

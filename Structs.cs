using System;
using ObjCRuntime;

[Native]
public enum TVOLogLevel : ulong
{
	Off = 0,
	Error,
	Warn,
	Info,
	Debug,
	Verbose
}

[Native]
public enum TVOLogModule : ulong
{
	Pjsip = 0,
	Notify
}

[Native]
public enum TVOCallInviteState : ulong
{
	Pending = 0,
	Accepted,
	Rejected,
	Cancelled
}

[Native]
public enum TVOCallState : ulong
{
	Connecting = 0,
	Connected,
	Disconnected
}

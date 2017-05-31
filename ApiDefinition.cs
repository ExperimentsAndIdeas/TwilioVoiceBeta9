using System;
using Foundation;
using ObjCRuntime;

namespace TwilioVoiceBeta9
{
	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double TwilioVoiceClientVersionNumber;
		[Field("TwilioVoiceClientVersionNumber", "__Internal")]
		double TwilioVoiceClientVersionNumber { get; }

		// extern const unsigned char [] TwilioVoiceClientVersionString;
		[Field("TwilioVoiceClientVersionString", "__Internal")]
		byte[] TwilioVoiceClientVersionString { get; }
	}

	// @protocol TVONotificationDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TVONotificationDelegate
	{
		// @required -(void)callInviteReceived:(TVOCallInvite * _Nonnull)callInvite;
		[Abstract]
		[Export("callInviteReceived:")]
		void CallInviteReceived(TVOCallInvite callInvite);

		// @required -(void)callInviteCancelled:(TVOCallInvite * _Nullable)callInvite;
		[Abstract]
		[Export("callInviteCancelled:")]
		void CallInviteCancelled([NullAllowed] TVOCallInvite callInvite);

		// @required -(void)notificationError:(NSError * _Nonnull)error;
		[Abstract]
		[Export("notificationError:")]
		void NotificationError(NSError error);
	}

	// @protocol TVOCallDelegate
	[Protocol, Model]
	interface TVOCallDelegate
	{
		// @required -(void)callDidConnect:(TVOCall * _Nonnull)call;
		[Abstract]
		[Export("callDidConnect:")]
		void CallDidConnect(TVOCall call);

		// @required -(void)callDidDisconnect:(TVOCall * _Nonnull)call;
		[Abstract]
		[Export("callDidDisconnect:")]
		void CallDidDisconnect(TVOCall call);

		// @required -(void)call:(TVOCall * _Nonnull)call didFailWithError:(id)error;
		[Abstract]
		[Export("call:didFailWithError:")]
		void Call(TVOCall call, NSObject error);
	}

	// @interface TVOCallInvite : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOCallInvite
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull from;
		[Export("from", ArgumentSemantic.Strong)]
		string From { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull to;
		[Export("to", ArgumentSemantic.Strong)]
		string To { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull callSid;
		[Export("callSid", ArgumentSemantic.Strong)]
		string CallSid { get; }

		// @property (readonly, assign, nonatomic) TVOCallInviteState state;
		[Export("state", ArgumentSemantic.Assign)]
		TVOCallInviteState State { get; }

		// -(TVOCall * _Nullable)acceptWithDelegate:(id<TVOCallDelegate> _Nonnull)delegate;
		[Export("acceptWithDelegate:")]
		[return: NullAllowed]
		TVOCall AcceptWithDelegate(TVOCallDelegate @delegate);

		// -(void)reject;
		[Export("reject")]
		void Reject();
	}

	// @interface CallKitIntegration (TVOCallInvite)
	[Category]
	[BaseType(typeof(TVOCallInvite))]
	interface TVOCallInvite_CallKitIntegration
	{
		// @property (readonly, nonatomic, strong) NSUUID * _Nonnull uuid;
		[Export("uuid", ArgumentSemantic.Strong)]
		NSUuid Uuid { get; }
	}


	// @interface TVOCall : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface TVOCall
	{
		[Wrap("WeakDelegate")]
		[NullAllowed]
		TVOCallDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TVOCallDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull from;
		[Export("from", ArgumentSemantic.Strong)]
		string From { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull to;
		[Export("to", ArgumentSemantic.Strong)]
		string To { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull callSid;
		[Export("callSid", ArgumentSemantic.Strong)]
		string CallSid { get; }

		// @property (getter = isMuted, assign, nonatomic) BOOL muted;
		[Export("muted")]
		bool Muted { [Bind("isMuted")] get; set; }

		// @property (readonly, assign, nonatomic) TVOCallState state;
		[Export("state", ArgumentSemantic.Assign)]
		TVOCallState State { get; }

		// -(void)disconnect;
		[Export("disconnect")]
		void Disconnect();

		// -(void)sendDigits:(NSString * _Nonnull)digits;
		[Export("sendDigits:")]
		void SendDigits(string digits);
	}

	// @interface CallKitIntegration (TVOCall)
	[Category]
	[BaseType(typeof(TVOCall))]
	interface TVOCall_CallKitIntegration
	{
		// @property (nonatomic, strong) NSUUID * _Nonnull uuid;
		[Export("uuid", ArgumentSemantic.Strong)]
		NSUuid Uuid { get; set; }
	}

}

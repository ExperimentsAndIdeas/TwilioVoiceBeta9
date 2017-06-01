using System;
using Foundation;
using ObjCRuntime;
 
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

// @interface TwilioVoice : NSObject
[BaseType(typeof(NSObject))]
interface TwilioVoice
{
	// @property (assign, nonatomic) TVOLogLevel logLevel;
	[Export("logLevel", ArgumentSemantic.Assign)]
	TVOLogLevel LogLevel { get; set; }

	// @property (getter = isPublishMetricsEnabled, assign, nonatomic) BOOL publishMetricsEnabled;
	[Export("publishMetricsEnabled")]
	bool PublishMetricsEnabled { [Bind("isPublishMetricsEnabled")] get; set; }

	// +(TwilioVoice * _Nonnull)sharedInstance;
	[Static]
	[Export("sharedInstance")]
	//[Verify(MethodToProperty)]
	TwilioVoice SharedInstance { get; }

	// -(NSString * _Nonnull)version;
	[Export("version")]
	//[Verify(MethodToProperty)]
	string Version { get; }

	// -(void)setModule:(TVOLogModule)module logLevel:(TVOLogLevel)level;
	[Export("setModule:logLevel:")]
	void SetModule(TVOLogModule module, TVOLogLevel level);

	// -(void)registerWithAccessToken:(NSString * _Nonnull)accessToken deviceToken:(NSString * _Nonnull)deviceToken completion:(void (^ _Nullable)(NSError * _Nullable))completion;
	[Export("registerWithAccessToken:deviceToken:completion:")]
	void RegisterWithAccessToken(string accessToken, string deviceToken, [NullAllowed] Action<NSError> completion);

	// -(void)unregisterWithAccessToken:(NSString * _Nonnull)accessToken deviceToken:(NSString * _Nonnull)deviceToken completion:(void (^ _Nullable)(NSError * _Nullable))completion;
	[Export("unregisterWithAccessToken:deviceToken:completion:")]
	void UnregisterWithAccessToken(string accessToken, string deviceToken, [NullAllowed] Action<NSError> completion);

	// -(void)handleNotification:(NSDictionary * _Nonnull)payload delegate:(id<TVONotificationDelegate> _Nullable)delegate;
	[Export("handleNotification:delegate:")]
	void HandleNotification(NSDictionary payload, [NullAllowed] TVONotificationDelegate @delegate);

	// -(TVOCall * _Nullable)call:(NSString * _Nonnull)accessToken params:(NSDictionary<NSString *,NSString *> * _Nullable)twiMLParams delegate:(id<TVOCallDelegate> _Nullable)delegate;
	[Export("call:params:delegate:")]
	[return: NullAllowed]
	TVOCall Call(string accessToken, [NullAllowed] NSDictionary<NSString, NSString> twiMLParams, [NullAllowed] TVOCallDelegate @delegate);
}

// @interface CallKitIntegration (TwilioVoice)
[Category]
[BaseType(typeof(TwilioVoice))]
interface TwilioVoice_CallKitIntegration
{
	// -(void)configureAudioSession __attribute__((availability(ios, introduced=10.0)));
	[iOS(10, 0)]
	[Export("configureAudioSession")]
	void ConfigureAudioSession();

	// -(void)startAudioDevice __attribute__((availability(ios, introduced=10.0)));
	[iOS(10, 0)]
	[Export("startAudioDevice")]
	void StartAudioDevice();

	// -(void)stopAudioDevice __attribute__((availability(ios, introduced=10.0)));
	[iOS(10, 0)]
	[Export("stopAudioDevice")]
	void StopAudioDevice();
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

// @protocol TVOCallDelegate <NSObject>
[Protocol, Model]
[BaseType(typeof(NSObject))]
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

	// @required -(void)call:(TVOCall * _Nonnull)call didFailWithError:(NSError * _Nonnull)error;
	[Abstract]
	[Export("call:didFailWithError:")]
	void Call(TVOCall call, NSError error);
}

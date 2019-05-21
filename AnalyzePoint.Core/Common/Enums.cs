namespace AnalyzePoint.Core.Common
{
  /// <summary>
  /// Defines a set of values to describe the scope of a SharePoint feature definition.
  /// </summary>
  public enum FeatureScope
  {
    Invalid,
    None,
    Web,
    Site,
    WebApplication,
    Farm
  }

  /// <summary>
  /// Specifies the role of the server with respect to the Windows SharePoint Services deployment.
  /// </summary>  
  public enum ServerRole
  {
    /// <summary>
    /// Specifies that the server does not have a registered role in the configuration database.
    /// </summary>
    Invalid = 0,

    /// <summary>
    /// Specifies that the server is a front-end Web server within the Windows SharePoint Services deployment.
    /// </summary>    
    WebFrontEnd = 1,

    /// <summary>
    /// Specifies that the server runs a Web application.
    /// </summary>     
    Application = 2,

    /// <summary>
    /// Specifies that the server is the only server in the Windows SharePoint Services deployment.
    /// </summary>
    SingleServer = 3,
    SingleServerFarm = 4,
    DistributedCache = 5,
    Search = 6,
    Custom = 8,
    ApplicationWithSearch = 9,
    WebFrontEndWithDistributedCache = 10
  }

  /// <summary>
  /// Specifies the type of a SharePoint Service. 
  /// </summary>
  public enum ServiceType
  {
    Other,
    TimerService,
    CentralAdministrationService,
    ContentService,
    DatabaseService,
    OutboundEmailService,
    IncomingEmailService,
    DiagnosticsService,
    UserCodeService,
    WindowsService,
    TracingService,
    UsageService,
    IisWebService,
    LoadBalancerService,
    RequestManagementService
  }

  public enum EventReceiverEventType
  {
    //
    // Summary:
    //     Invalid.
    InvalidReceiver = -1,
    //
    // Summary:
    //     An item is being added.
    ItemAdding = 1,
    //
    // Summary:
    //     An item is being updated.
    ItemUpdating = 2,
    //
    // Summary:
    //     An item is being deleted.
    ItemDeleting = 3,
    //
    // Summary:
    //     An item is being checked in.
    ItemCheckingIn = 4,
    //
    // Summary:
    //     An item is being checked out.
    ItemCheckingOut = 5,
    //
    // Summary:
    //     An item is being unchecked out.
    ItemUncheckingOut = 6,
    //
    // Summary:
    //     An attachment is being added to the item.
    ItemAttachmentAdding = 7,
    //
    // Summary:
    //     An attachment is being removed from the item.
    ItemAttachmentDeleting = 8,
    //
    // Summary:
    //     A file is being moved.
    ItemFileMoving = 9,
    ItemVersionDeleting = 11,
    //
    // Summary:
    //     A field is being added.
    FieldAdding = 101,
    //
    // Summary:
    //     A field is being updated.
    FieldUpdating = 102,
    //
    // Summary:
    //     A field is being removed.
    FieldDeleting = 103,
    ListAdding = 104,
    ListDeleting = 105,
    //
    // Summary:
    //     A site collection is being deleted.
    SiteDeleting = 201,
    //
    // Summary:
    //     A site is being deleted.
    WebDeleting = 202,
    //
    // Summary:
    //     A site is being moved.
    WebMoving = 203,
    WebAdding = 204,
    GroupAdding = 301,
    GroupUpdating = 302,
    GroupDeleting = 303,
    GroupUserAdding = 304,
    GroupUserDeleting = 305,
    RoleDefinitionAdding = 306,
    RoleDefinitionUpdating = 307,
    RoleDefinitionDeleting = 308,
    RoleAssignmentAdding = 309,
    RoleAssignmentDeleting = 310,
    InheritanceBreaking = 311,
    InheritanceResetting = 312,
    WorkflowStarting = 501,
    //
    // Summary:
    //     An item was added.
    ItemAdded = 10001,
    //
    // Summary:
    //     An item was updated.
    ItemUpdated = 10002,
    //
    // Summary:
    //     An item was deleted.
    ItemDeleted = 10003,
    //
    // Summary:
    //     An item was checked in.
    ItemCheckedIn = 10004,
    //
    // Summary:
    //     An item was checked out.
    ItemCheckedOut = 10005,
    //
    // Summary:
    //     An item was unchecked out.
    ItemUncheckedOut = 10006,
    //
    // Summary:
    //     An attachment was added to the item.
    ItemAttachmentAdded = 10007,
    //
    // Summary:
    //     An attachment was removed from the item.
    ItemAttachmentDeleted = 10008,
    //
    // Summary:
    //     A file was moved.
    ItemFileMoved = 10009,
    //
    // Summary:
    //     A file was converted.
    ItemFileConverted = 10010,
    ItemVersionDeleted = 10011,
    //
    // Summary:
    //     A field was added.
    FieldAdded = 10101,
    //
    // Summary:
    //     A field was updated.
    FieldUpdated = 10102,
    //
    // Summary:
    //     A field was removed.
    FieldDeleted = 10103,
    ListAdded = 10104,
    ListDeleted = 10105,
    //
    // Summary:
    //     A site collection was deleted.
    SiteDeleted = 10201,
    //
    // Summary:
    //     A site was deleted.
    WebDeleted = 10202,
    //
    // Summary:
    //     A site was moved.
    WebMoved = 10203,
    WebProvisioned = 10204,
    WebRestored = 10205,
    GroupAdded = 10301,
    GroupUpdated = 10302,
    GroupDeleted = 10303,
    GroupUserAdded = 10304,
    GroupUserDeleted = 10305,
    RoleDefinitionAdded = 10306,
    RoleDefinitionUpdated = 10307,
    RoleDefinitionDeleted = 10308,
    RoleAssignmentAdded = 10309,
    RoleAssignmentDeleted = 10310,
    InheritanceBroken = 10311,
    InheritanceReset = 10312,
    WorkflowStarted = 10501,
    WorkflowPostponed = 10502,
    WorkflowCompleted = 10503,
    EntityInstanceAdded = 10601,
    EntityInstanceUpdated = 10602,
    EntityInstanceDeleted = 10603,
    AppInstalled = 10701,
    AppUpgraded = 10702,
    AppUninstalling = 10703,
    //
    // Summary:
    //     The list received an e-mail message.
    EmailReceived = 20000,
    //
    // Summary:
    //     The list received a context event.
    ContextEvent = 32766
  }
}

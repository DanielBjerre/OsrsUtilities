namespace OsrsUtilities.GroupService.Contracts;

public record CreateGroupRequest(string Name, string Description, string OwnerId);
public record CreateGroupResponse(Guid GroupId);

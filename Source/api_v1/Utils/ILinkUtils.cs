﻿// Kerbal Attachment System API
// Mod idea: KospY (http://forum.kerbalspaceprogram.com/index.php?/profile/33868-kospy/)
// API design and implemenation: igor.zavoychinskiy@gmail.com
// License: Public Domain

using System;

// Name of the namespace denotes the API version.
namespace KASAPIv1 {

/// <summary>Various tools to deal with KAS links.</summary>
public interface ILinkUtils {
  /// <summary>Finds linked target given the link source.</summary>
  /// <remarks>
  /// Any number of targets can be linked to the source part but only one can be linked with a
  /// particular source. This method goes over the all targets on the target part, and returns the
  /// target that is linked with the provided source.
  /// <para>
  /// It's discouraged to implement this logic in own code since the linking approach may change in
  /// the future versions.
  /// </para>
  /// </remarks>
  /// <param name="source">The source to get the target for.</param>
  /// <returns>The target or <c>null</c> if no valid target was found.</returns>
  ILinkTarget FindLinkTargetFromSource(ILinkSource source);

  /// <summary>Finds linked source given the link target.</summary>
  /// <remarks>
  /// Only one source on the part can be linked. This method goes over all sources on the source
  /// part, and returns the one that is linked with the provided target.
  /// <para>
  /// It's discouraged to implement this logic in own code since linking approach may change in the
  /// future versions.
  /// </para>
  /// </remarks>
  /// <param name="target">target to get source for.</param>
  /// <returns>Source or <c>null</c> if no valid source was found.</returns>
  ILinkSource FindLinkSourceFromTarget(ILinkTarget target);

  /// <summary>Couples two parts together given they belong to different vessels.</summary>
  /// <remarks>
  /// Once coupling is done the source vessel will be destroyed, and become a part of the target
  /// vessel. The new target vessel will become active.
  /// </remarks>
  /// <para>Attach nodes must have valid <c>owner</c> set.</para>
  /// <param name="sourceNode">
  /// Attach node at the source part that defines the source vessel.
  /// </param>
  /// <param name="targetNode">
  /// Attach node at the target part that defines the target vessel.
  /// </param>
  /// <returns>Source vessel info. This vessel gets destroyed on couple.</returns>
  DockedVesselInfo CoupleParts(AttachNode sourceNode, AttachNode targetNode);

  /// <summary>Decouples conencted parts and breaks down one vessel into two.</summary>
  /// <param name="part1">
  /// First part of the connection. It muts be a direct parent or child of <paramref name="part2"/>.
  /// </param>
  /// <param name="part2">
  /// Second part of the connection. It muts be a direct parent or child of
  /// <paramref name="part1"/>.
  /// </param>
  /// <returns>Inactive vessel that was created as a result of decoupling.</returns>
  Vessel DecoupleParts(Part part1, Part part2);
}

}  // namespace

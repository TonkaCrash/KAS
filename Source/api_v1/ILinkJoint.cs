﻿// Kerbal Attachment System API
// Mod idea: KospY (http://forum.kerbalspaceprogram.com/index.php?/profile/33868-kospy/)
// API design and implemenation: igor.zavoychinskiy@gmail.com
// License: Public Domain

using KASAPIv1;

namespace KASAPIv1 {

/// <summary>Base interface for a KAS joint.</summary>
/// <remarks>
/// <para>
/// Every KAS part <b>must</b> have a joint module that controls how KAS joints are maintained. If
/// the part doesn't implement any special joint logic then a <see cref="KAS.KASModuleStockJoint"/>
/// can be used.
/// </para>
/// <para>
/// This interface is primarily designed for use form the <see cref="ILinkSource"/> implementations.
/// A third-party code must not interact with it directly.
/// </para>
/// </remarks>
public interface ILinkJoint : ILinkJointBase {
  /// <summary>Minimum allowed distance between parts to establish a link.</summary>
  /// <value>Distance in meters. <c>0</c> if no limit for minimum value is applied.</value>
  float cfgMinLinkLength { get; }

  /// <summary>Maximum allowed distance between parts to establish a link.</summary>
  /// <value>Distance in meters. <c>0</c> if no limit for maximum value is applied.</value>
  float cfgMaxLinkLength { get; }

  /// <summary>Breaking force for the strut connecting the two parts.</summary>
  /// <value>
  /// Force in kilonewtons. <c>0</c> if the joint strength is calculated automatically.
  /// </value>
  float cfgLinkBreakForce { get; }

  /// <summary>Breaking torque for the link connecting the two parts.</summary>
  /// <value>
  /// Force in kilonewtons. <c>0</c> if the joint strength is calculated automatically.
  /// </value>
  float cfgLinkBreakTorque { get; }

  /// <summary>
  /// Maximum allowed angle between the attach node normal and the link at the source part.
  /// </summary>
  /// <value>Angle in degrees. <c>0</c> if angle is not checked.</value>
  int cfgSourceLinkAngleLimit { get; }

  /// <summary>
  /// Maximum allowed angle between the attach node normal and the link at the target part.
  /// </summary>
  /// <value>Angle in degrees. <c>0</c> if angle is not checked.</value>
  int cfgTargetLinkAngleLimit { get; }

  /// <summary>Requests the joint to become unbreakable or normal.</summary>
  /// <remarks>
  /// Normally, joint is set to unbreakable on time warp, but in general callers may do it at any
  /// moment. In unbreakable state joint must behave as a hard connection that cannot be changed or
  /// destructed by any force.</remarks>
  /// <param name="isUnbreakable">If <c>true</c> then joint must become unbreakable.</param>
  void AdjustJoint(bool isUnbreakable = false);
}

}  // namespace

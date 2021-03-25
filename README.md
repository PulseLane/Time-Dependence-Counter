# Time Dependence Counter

This mod adds a counter that shows how "time dependent" your cuts are, on a scale from 0-1. 

"Time dependence" refers to how much the accuracy part of your score (the 15 points for hitting close to the center) depends on timing: i.e. if you were to hit earlier or later in time, how much your score would vary by. It is **not** a measure of how good your timing is, nor does it say anything about how good your accuracy is. A 0 indicates a completely time independent cut - no matter how early/late you hit the bloq your accuracy score will not change. A 1 indicates a maximally time-dependent cut - your score will vary significantly if you hit slightly earlier or later.

For a more in-depth expalanation of TD, refer to this document put together by DuhHello: https://docs.google.com/document/d/1Q8-naaDUfAB-bDhcBDgV7McSgI0iaoMTJKDDk-9PHR8/

The time dependence is measured by the Z component of the normal to your cut plane, see the following for a derivation:

![Proof](/Images/proof.png)

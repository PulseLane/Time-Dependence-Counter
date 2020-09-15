# Time Dependence Counter

This mod adds a counter that shows how "time dependent" your cuts are, on a scale from 0-1. 

"Time dependence" refers to how much the accuracy part of your score (the 15 points for hitting close to the center) depends on timing: i.e. if you were to hit earlier or later in time, how much your score would vary by. A 0 indicates a completely time independent - no matter how early/late you hit the bloq your accuracy score will not change. A 1 indicates a maximally time-dependent cut - your score will vary significantly if you hit slightly earlier or later.

The time dependence is measured by the Z component of the normal to your cut plane, see the following for a derivation:

![Proof](/Images/proof.png)

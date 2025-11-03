Game Performance One-Pager
*Author:* Bobby Hayes  
*Course:* CSS 385 – Game Development  
*Assignment:* Game Performance One-Pager  

1. Sources of Performance Concerns

Source of Concern | Explanation |
1 | Rendering Complexity  | High-resolution textures, complex shaders, and too many draw calls can strain GPU performance, leading to frame drops. |
2 | Physics and Collision Calculations | Real-time collision detection or physics simulations (e.g., ragdoll or projectile interactions) can cause CPU bottlenecks. |
3 | Memory Management & Asset Loading  | Inefficient memory allocation or large asset loads during gameplay can cause stuttering or long load times. |

2. Strategies to Address Each Concern

| Concern | Common Optimization Strategy | Description |
| Rendering Complexity | Level of Detail (LOD) & Object Culling | Use simplified models or textures for distant objects and skip rendering objects outside the camera’s frustum. |
| Physics Calculations | Fixed Timestep & Simplified Colliders | Use a fixed timestep for physics updates and approximate collider shapes (e.g., spheres or capsules instead of mesh colliders). |
| Memory Management | Object Pooling & Asset Streaming | Reuse frequently spawned objects instead of destroying/re-instantiating them, and stream assets dynamically as needed. |

3. Application to My Game
- Rendering Optimization: I plan to use object culling to prevent rendering off-screen enemies or decorations. This should improve FPS and reduce GPU load.
- Physics Optimization: By implementing simplified colliders, combat detection will remain accurate while reducing CPU usage.
- Memory Management: Object pooling will be used for projectiles and particle effects, minimizing GC spikes and ensuring smooth gameplay.

These combined strategies align with my goal of achieving consistent frame rates above 60 FPS while maintaining visual quality and responsiveness.

4. References
- Gregory, Jason. Game Engine Architecture, 3rd Edition, CRC Press, 2018.  
- Unity Technologies. “Optimizing Game Performance.” Unity Manual, 2025.  
- Unreal Engine Documentation. “Performance and Profiling.” Epic Games, 2025.  
   

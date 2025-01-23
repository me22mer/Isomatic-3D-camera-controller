# CameraController

A flexible and customizable **Camera Controller** for Unity that supports **smooth following, panning, zooming, and rotation**.

## Features
- **Smooth Following**: Follows a target object with adjustable smoothness.
- **Panning**: Move the camera using keyboard input with optional movement limits.
- **Zooming**: Adjust zoom level with mouse scroll with min/max zoom constraints.
- **Rotation**: Rotate the camera using right mouse drag with smooth transition.

## Installation
1. Clone this repository or copy the `CameraController.cs` script into your Unity project.
2. Attach the `CameraController` script to your **Main Camera** or any desired camera GameObject.
3. Assign a target to `FollowAt` if needed.

## Usage
### 1. Follow Settings
- `FollowAt`: Assign a Transform to make the camera follow that object.
- `FollowSmoothness`: Adjusts how smoothly the camera follows the target.

### 2. Panning Settings
- `EnablePanLimitX` / `EnablePanLimitZ`: Enable or disable movement constraints.
- `PanLimitX` / `PanLimitZ`: Set min and max limits for panning.
- `PanSpeed`: Adjusts the speed of panning.

### 3. Zoom Settings
- `ZoomSpeed`: Controls how fast the zooming occurs.
- `ZoomSmoothness`: Controls the smoothness of zooming.
- `MinZoom` / `MaxZoom`: Set limits for zooming.

### 4. Rotation Settings
- `RotationSpeed`: Controls how fast the camera rotates.
- Right mouse button (`Mouse 1`): Drag to rotate.
- Auto-snaps to 45-degree increments when released.

## Controls
| Action       | Input |
|-------------|-------|
| Move Camera | Arrow Keys / WASD |
| Zoom        | Mouse Scroll |
| Rotate      | Right Mouse Drag |

## License
This project is licensed under the **MIT License**. Feel free to use and modify it for your needs!

## Credits ❤️

This camera controller was inspired by and made with the help of the following creators:

- [@bitcuttertaylor](https://www.youtube.com/@bitcuttertaylor)
- [@t3ssel8r](https://www.youtube.com/watch?v=ij555s4mAuI)

---
**Happy coding! 🚀**

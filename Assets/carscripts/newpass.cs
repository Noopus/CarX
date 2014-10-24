using UnityEngine;
using System.Collections;

public class newpass : MonoBehaviour {
		private Vector3 size;
		private Vector3 center;
		// Give a bit of space between the raycast and boxCollider to prevent ray going through collision layer.
		private float skin = .005f;
		
		private LayerMask collisionMask;
		private LayerMask playerMask;
		
		public bool OnGround { get; set; }
		public bool SideCollision { get; set; }
		
		public void Init(BoxCollider boxCollider, LayerMask collisionMask, LayerMask playerMask) {
			this.collisionMask = collisionMask;
			this.playerMask = playerMask;
			size = boxCollider.size;
			center = boxCollider.center;
		}
		
		public Vector3 Move(Vector3 moveAmount, Vector3 position, float dirX) {
			float deltaX = moveAmount.x;
			float deltaY = moveAmount.y;
			Vector3 entityPosition = position;
			// Resolve any possible collisions below and above the entity.
			deltaY = yAxisCollisions(deltaY, dirX, entityPosition);
			// Resolve any possible collisions left and right of the entity.
			// Check if our deltaX value is 0 to avoid unnecessary collision detection.
			if (deltaX != 0) {
				deltaX = xAxisCollisions(deltaX, entityPosition);
			}
			Vector3 finalTransform = new Vector2(deltaX, deltaY);
			return finalTransform;
		}
		private float xAxisCollisions(float deltaX, Vector3 entityPosition) {
			SideCollision = false;
			float i;
			// If we are on the ground, perform just three, normal sized raycasts.
			if (OnGround) {
				i = 0;
				// Else, perform a larger range of raycasts that extend slightly outside of
				// the box collider in order to prevent falling through corners in the Collisions layermask.
			} else {
				i = -0.5f;
			}
			for (; i < 3; ++i) {
				float dirX = Mathf.Sign(deltaX);
				
				float x = entityPosition.x + center.x + size.x / 2 * dirX;
				float y = (entityPosition.y + center.y - size.y / 2) + size.y / 2 * i;
				
				RaycastHit hit;
				Ray rayX = new Ray(new Vector2(x, y), new Vector2(dirX, 0));
				
				Debug.DrawRay(rayX.origin, rayX.direction);
				
				if (Physics.Raycast(rayX, out hit, Mathf.Abs(deltaX), collisionMask) ||
				    Physics.Raycast(rayX, out hit, Mathf.Abs(deltaX), playerMask)) {
					Debug.DrawRay(rayX.origin, rayX.direction, Color.yellow);
					deltaX = 0;
					SideCollision = true;
					break;
				}
			}
			
			return deltaX;
		}
		
		private float yAxisCollisions(float deltaY, float dirX, Vector3 entityPosition) {
			OnGround = false;
			// To prevent falling through collision layers by a gap in the corner
			// if we are facing right, peform y-axis raycasts starting on the right.
			int facingRight = 1;
			if (dirX == facingRight) {
				for (int i = 2; i > -1; --i) {
					if (yAxisRaycasts(i, ref deltaY, entityPosition)) {
						break;
					}
				}
				// else we are facing left, peform y-axis raycasts starting on the left
			} else {
				for (int i = 0; i < 3; ++i) {
					if (yAxisRaycasts(i, ref deltaY, entityPosition)) {
						break;
					}
				}
			}
			
			return deltaY;
		}
		
		private bool yAxisRaycasts(int i, ref float deltaY, Vector3 entityPosition) {
			float dirY = Mathf.Sign(deltaY);
			// Start at the left or the right of the boxCollider, depending on the value of i.
			float x = (entityPosition.x + center.x - size.x / 2) + size.x / 2 * i;
			// Bottom or top of boxCollider, depending on if dirY is positive or negative
			float y = entityPosition.y + center.y + size.y / 2 * dirY;
			
			RaycastHit hit;
			Ray ray = new Ray(new Vector2(x, y), new Vector2(0, dirY));
			
			Debug.DrawRay(ray.origin, ray.direction);
			
			if (Physics.Raycast(ray, out hit, Mathf.Abs(deltaY), collisionMask) ||
			    Physics.Raycast(ray, out hit, Mathf.Abs(deltaY), playerMask)) {
				Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
				// Get Distance between entity and ground
				float distance = Vector3.Distance(ray.origin, hit.point);
				// Stop entity's downward movement after coming within skin width of a boxCollider
				if (distance > skin) {
					deltaY = distance * dirY + skin;
				} else {
					deltaY = 0;
				}
				OnGround = true;
				return true;
			}
			
			return false;
		}
	}
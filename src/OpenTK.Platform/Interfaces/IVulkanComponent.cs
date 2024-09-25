﻿using OpenTK.Graphics.Vulkan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTK.Platform
{
    /// <summary>
    /// Interface for creating and interacting with vulkan.
    /// </summary>
    public interface IVulkanComponent : IPalComponent
    {
        /// <summary>
        /// Returns a list of required instance extensions required for
        /// <see cref="GetPhysicalDevicePresentationSupport(VkInstance, VkPhysicalDevice, uint)"/> and
        /// <see cref="CreateWindowSurface(VkInstance, WindowHandle, VkAllocationCallbacks*, out VkSurfaceKHR)"/>
        /// to work. Include these extensions when creating <see cref="VkInstance"/>.
        /// </summary>
        /// <returns></returns>
        public ReadOnlySpan<string> GetRequiredInstanceExtensions();

        /// <summary>
        /// Returns true of the given queue family supports presentation to a surface created with <see cref="CreateWindowSurface(VkInstance, WindowHandle, VkAllocationCallbacks*, out VkSurfaceKHR)"/>.
        /// </summary>
        /// <param name="instance">The <see cref="VkInstance"/> to physical device belongs to.</param>
        /// <param name="device">The <see cref="VkPhysicalDevice"/> that the <paramref name="queueFamily"/> belongs to.</param>
        /// <param name="queueFamily">The index of the queue family to query for presentation support.</param>
        /// <returns></returns>
        public unsafe bool GetPhysicalDevicePresentationSupport(VkInstance instance, VkPhysicalDevice device, uint queueFamily);

        /// <summary>
        /// Creates a Vulkan surface for the specified window.
        /// </summary>
        /// <param name="instance">The instance to create the surface with.</param>
        /// <param name="window">The window to create the surface in.</param>
        /// <param name="allocator">The allocator to use or <see langword="null"/> to use the default allocator.</param>
        /// <param name="surface">The created surface.</param>
        /// <returns>The Vulkan result code of this operation.</returns>
        public unsafe VkResult CreateWindowSurface(VkInstance instance, WindowHandle window, VkAllocationCallbacks* allocator, out VkSurfaceKHR surface);

        // FIXME: Vulkan error to readable string function.
    }
}

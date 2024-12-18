<?php
if ( ! defined( 'BP_AVATAR_FULL_WIDTH' ) )
    define( 'BP_AVATAR_FULL_WIDTH', 500 ); //change this with your desired full
 
if ( ! defined( 'BP_AVATAR_FULL_HEIGHT' ) )
    define( 'BP_AVATAR_FULL_HEIGHT', 500 ); //change this to default height for full avatar

    // Disable Lasy Load on Change avatar pages !
function yzc_disable_lazy_load_on_change_avatar_pages( $enabled ) {

	if ( bp_is_user_change_avatar() ) {
		return false;
	}

	if ( bp_is_active( 'groups' ) && ( bp_is_group_creation_step( 'group-avatar' )
		 || bp_is_group_admin_screen( 'group-avatar' ) ) ) {
		return false;
	}

	return $enabled;

}

add_filter( 'lazyload_is_enabled', 'yzc_disable_lazy_load_on_change_avatar_pages' );


/**
 * Reset Widgets.
 */
function yzc_reset_widgets() {

    if ( ! get_option( 'youzify_reset_widgets100' ) ) {

        // Delete OLD DATA.
        delete_option( 'youzify_profile_main_widgets' );
        delete_option( 'youzify_profile_sidebar_widgets' );
        delete_option( 'youzify_profile_left_sidebar_widgets' );

        update_option( 'youzify_reset_widgets100', 1, 'no' );

    }

}

add_action( 'init', 'yzc_reset_widgets' );

/**
 * Disable Widgets Settings.
 */
function yzc_disable_widgets_settings( $is_current_component, $component) {
    if ( $component =='widgets' ) {
        return false;
    }
    return $is_current_component;
}

add_filter( 'bp_is_current_component', 'yzc_disable_widgets_settings', 10, 2 );

/**
 * Remove Widgets Settings from Account Menu.
 */
function yzc_remove_widgets_settings_account_menu( $menu ) {
    unset($menu['widgets'] );
    return $menu;
}

add_filter( 'youzify_account_page_main_menu', 'yzc_remove_widgets_settings_account_menu' );

/**
 * Remove Widgets Settings from Profile Menu.
 */
function yzc_remove_widgets_settings_profile_menu( $menu ) {
    unset( $menu['widgets'] );
    return $menu;
}

add_filter( 'youzify_get_profile_account_menu', 'yzc_remove_widgets_settings_profile_menu' );
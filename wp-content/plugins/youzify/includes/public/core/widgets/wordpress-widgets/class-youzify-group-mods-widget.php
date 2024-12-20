<?php

/**
 * Group Moderators Widget
 */

class Youzify_Group_Mods_Widget extends WP_Widget {

	function __construct() {
		parent::__construct(
			'youzify_group_moderators_widget',
			__( 'Youzify - Group Moderators', 'youzify' ),
			array( 'description' => __( 'Group moderators widget', 'youzify' ) )
		);
	}

	/**
	 * Back-end widget form.
	 */
	public function form( $instance ) {

	    // Get Widget Data.
	    $instance = wp_parse_args( (array) $instance,
	    	array(
		    	'title' => __( 'Group Moderators', 'youzify' ),
		        'limit' => '10',
	    	)
	    );

	    // Get Input's Data.
		$limit = absint( $instance['limit'] );
		$title = strip_tags( $instance['title'] );

		?>

		<!-- Title. -->
		<p>
			<label for="<?php echo $this->get_field_id( 'title' ); ?>"><?php _e( 'Title', 'youzify' ); ?></label>
			<input type="text" id="<?php echo $this->get_field_id( 'title' ); ?>" name="<?php echo $this->get_field_name( 'title' ); ?>" class="widefat" value="<?php echo esc_attr( $title ); ?>">
		</p>

		<!-- Mods Number. -->
		<p>
			<label for="<?php echo $this->get_field_id( 'limit' ); ?>"><?php _e( 'Moderators Number:', 'youzify' ); ?>
				<input class="widefat" id="<?php echo $this->get_field_id( 'limit' ); ?>" name="<?php echo $this->get_field_name( 'limit' ); ?>" type="text" value="<?php echo esc_attr( $limit ); ?>" style="width: 30%">
			</label>
		</p>

		<?php
	}

	/**
	 * Sanitize widget form values as they are saved.
	 */
	public function update( $new_instance, $old_instance ) {

		$instance = array();

		$instance = $old_instance;
		$instance['limit'] = absint( $new_instance['limit'] );
		$instance['title'] = strip_tags( $new_instance['title'] );

		return $instance;
	}

	/**
	 * Widget Content
	 */
	public function widget( $args, $instance ) {

		if ( ! bp_is_active( 'groups' ) ) {
			return false;
		}

		if ( bp_group_has_members(
			array( 'per_page' => $instance['limit'], 'group_role' => array( 'mod' ) )
			)) {

			echo $args['before_widget'];

			if ( ! empty( $instance['title'] ) ) {
				echo $args['before_title'];
				echo apply_filters( 'widget_title', $instance['title'] );
				echo $args['after_title'];
			}

			$this->get_mods_list( $instance );

			echo $args['after_widget'];

		}

	}

	/**
	 * Get Mods List.
	 */
	function get_mods_list( $args ) {

		?>

		<div class="youzify-items-list-widget youzify-groups-admins-widget youzify-list-avatar-circle">

			<?php while ( bp_group_members() ) : bp_group_the_member(); ?>

			<?php $member_id = bp_get_group_member_id(); ?>
			<?php $profile_url = bp_members_get_user_url( $member_id ); ?>

			<div class="youzify-list-item">
				<a href="<?php echo $profile_url; ?>" class="youzify-item-avatar"><?php echo bp_core_fetch_avatar( array( 'item_id' => $member_id, 'type' => 'thumb' ) ); ?></a>
				<div class="youzify-item-data">
					<a href="<?php echo $profile_url; ?>" class="youzify-item-name"><?php echo bp_core_get_user_displayname( $member_id ); ?><?php youzify_the_user_verification_icon( $member_id ); ?></a>
					<div class="youzify-item-meta">
						<div class="youzify-meta-item">@<?php echo bp_members_get_user_slug( $member_id ); ?></div>
					</div>
				</div>
			</div>

			<?php endwhile; ?>

		</div>

		<?php

	}

}